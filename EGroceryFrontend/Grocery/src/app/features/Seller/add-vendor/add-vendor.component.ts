import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatDatepicker } from '@angular/material/datepicker';

@Component({
  selector: 'app-add-vendor',
  templateUrl: './add-vendor.component.html',
  styleUrls: ['./add-vendor.component.css']
})
export class AddVendorComponent {
  form!: FormGroup;
  hidePassword: boolean = true;

  @ViewChild('picker') picker!: MatDatepicker<Date>;

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.form = this.fb.group({
      companyName: ['', Validators.required],
      fssai: [''],
      gst: ['', Validators.required],
      phonenumber: ['', Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(10)])],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      termsAgreed: [false, Validators.requiredTrue]
    });
  }

  togglePasswordVisibility(): void {
    this.hidePassword = !this.hidePassword;
  }

  onSubmit() {

    const registerRequest = {
      companyName: this.form.value.companyName,
      fssai: this.form.value.fssai,
      gst: this.form.value.gst,
      mobileNo: this.form.value.phonenumber,
      emailId: this.form.value.email,
      password: this.form.value.password,
    };

    this.http.post('http://localhost:5148/api/Vendor/AddVendor', registerRequest).subscribe((response: any) => {
      alert('Vendor added successfully');
      this.router.navigate(['/vendor']);
    }, (error) => {
      console.log(error);
      alert('Error registering.');
    });
  }
}
