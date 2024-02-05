import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  firstName: string;
  lastName: string;
  birthDate: Date;
  phoneNumber: string;
  userName: string;
  email: string;
  password: string;

  constructor(private http: HttpClient, private router: Router) {
      this.firstName = '';
      this.lastName = '';
      this.birthDate = new Date();
      this.phoneNumber = '';
      this.userName = '';
      this.email = '';
      this.password = '';
  }

  onSubmit() {
    this.http.post<{ statusCode: number, message: string }>('/api/User/SignUp', {
        firstName: this.firstName,
        lastName: this.lastName,
        birthDate: this.birthDate,
        phoneNumber: this.phoneNumber,
        userName: this.userName,
        email: this.email,
        password: this.password
    })
    .subscribe(
        res => {
            if (res.statusCode === 200) {

                this.router.navigate(['/log-in-component']);
            } else {

                alert(res.message);
            }
        },
        err => {

            alert(err.error.message);
        }
    );
}

}

