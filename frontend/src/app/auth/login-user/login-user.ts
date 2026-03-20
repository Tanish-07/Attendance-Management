import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login-user',
  imports: [RouterLink,FormsModule],
  templateUrl: './login-user.html',
  styleUrl: './login-user.css',
})
export class LoginUser {
  http = inject(HttpClient);
  router = inject(Router);

  loginObj = {
    emailId: "",
    password: ""
  };

  onLogin() {
    this.http.post("https://localhost:7231/api/DbContext/login", this.loginObj).subscribe((result: any) => {
      alert("Login Successful");
      this.router.navigateByUrl("/dashboard/user");
    }, error => {
      alert(error.error.message);
    });
  }
}
