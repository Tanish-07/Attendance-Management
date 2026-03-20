import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { error } from 'console';

@Component({
  selector: 'app-contact',
  imports: [FormsModule],
  templateUrl: './contact.html',
  styleUrl: './contact.css',
})
export class Contact {

  contactObj: any = {
    fullName: "",
    emailId: "",
    message: ""
  };

  http=inject(HttpClient);
  router=inject(Router);

  submitContactForm() {
    this.http.post("https://localhost:7271/api/DbContext/contact", this.contactObj).subscribe((result:any)=>{
      alert("Your message has been submitted successfully!");
    },error=>{
      alert("There was an error submitting the form. Please try again later.");
    });
  }
    

}
