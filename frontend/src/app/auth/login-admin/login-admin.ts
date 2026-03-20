import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login-admin',
  imports: [RouterLink,FormsModule],
  templateUrl: './login-admin.html',
  styleUrl: './login-admin.css',
})
export class LoginAdmin {
  http = inject(HttpClient);
  router = inject(Router);

  adminObj = {
    emailId: "",
    password: ""
  };

  onadmin() {
    this.http.post("https://localhost:7231/api/DbContext/adminLog", this.adminObj).subscribe((result: any) => {
      alert("Login Successful");
      this.router.navigateByUrl("/dashboard/admin");
    }, error => {
      alert(error.error.message);
    });
  }
}
