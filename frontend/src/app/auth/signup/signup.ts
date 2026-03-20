import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from "@angular/router";
import { error } from 'console';

@Component({
  selector: 'app-signup',
  imports: [RouterLink,FormsModule],
  templateUrl: './signup.html',
  styleUrl: './signup.css',
})
export class Signup {
  http = inject(HttpClient);
  router = inject(Router);

  registerObj = {
    fullName: "",
    emailId: "",
    password: "",
    confirmPassword: ""
  };

  onRegister() {
    if (this.registerObj.password !== this.registerObj.confirmPassword) {
      alert("Passwords do not match!");
      return;
    }


    this.http.post("https://localhost:7231/api/DbContext/signup", this.registerObj).subscribe((result: any) => {
      alert("Registration Successful");
      this.router.navigateByUrl("/login/user");
    }, error => {
      alert(error.error);
    });
  }
}
