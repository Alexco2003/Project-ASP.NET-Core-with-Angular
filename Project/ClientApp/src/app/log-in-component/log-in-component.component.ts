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
                    // Store the token in the local storage
                    localStorage.setItem('token', res.token);
                    // Redirect to the home page
                    this.router.navigate(['/']);
                },
                err => {
                    // Display the error message
                    alert(err.error.message);
                }
            );
    }
}
