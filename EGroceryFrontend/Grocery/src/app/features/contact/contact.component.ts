import { Component } from '@angular/core';
import { FormGroup, FormBuilder} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
  form!: FormGroup;
  constructor(
    private fb: FormBuilder,
     private http: HttpClient
    ) {  }
    ngOnInit() {
      this.form = this.fb.group({
        firstName: [''],
        lastName: [''],
        email: [''],
        number: [''],
        message: [''],
      });
    }
    
    onSubmit() {
      const contact = {
        firstName: this.form.value.firstName,
        lastName: this.form.value.lastName,
        email: this.form.value.email,
        number: this.form.value.number,
        message: this.form.value.message
      };
     console.log(contact);
      this.http.post('http://localhost:5148/api/contact', contact).subscribe((response: any) => {
        // Handle the response here as text
        localStorage.setItem('token', response);
        alert("Message sent successfully")
        this.form.reset(); // Reset the form
      }, (error) => {
       
        alert('Message Sending Error');
      });
    }
}
