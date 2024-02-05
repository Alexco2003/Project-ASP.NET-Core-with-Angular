import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-log-in-component',
  templateUrl: './log-in-component.component.html',
  styleUrls: ['./log-in-component.component.css']
})
export class LogInComponentComponent {
  username: string;
  email: string;
  password: string;

  constructor(private http: HttpClient, private router: Router) {
    this.username = '';
    this.email = '';
    this.password = '';
  }

    onSubmit() {
        this.http.post<{ token: string }>('/api/User/Login', { email: this.email, username: this.username, password: this.password })
            .subscribe(
                res => {

                    localStorage.setItem('token', res.token);

                    this.router.navigate(['/']);
                },
                err => {

                    alert(err.error.message);
                }
            );
    }
}
