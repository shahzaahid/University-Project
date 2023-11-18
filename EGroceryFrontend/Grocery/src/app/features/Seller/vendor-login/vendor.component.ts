import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ServiceService } from '../dataSharing/vendor-service.service';

@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css']
})
export class VendorComponent implements OnInit {
  hidePassword: boolean = true;
  form!: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router, protected serviceService: ServiceService) { }

  ngOnInit() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });

    // Check if the user is already logged in by verifying the presence of a token
    const storedToken = localStorage.getItem('token');
    if (storedToken) {
      this.serviceService.setisloggedIn(true);
    }
  }

  togglePasswordVisibility(): void {
    this.hidePassword = !this.hidePassword;
  }

  onSubmit() {
    const loginRequest = {
      email: this.form.value.email,
      password: this.form.value.password
    };

    this.http.post('http://localhost:5148/api/Login/Vendor', loginRequest).subscribe((response: any) => {
      this.serviceService.setVendorId(response.vendorId);
      localStorage.setItem('token', response.token);
      alert("Login As Vendor successful");
      this.serviceService.setisloggedIn(true);
      this.form.reset();
      this.router.navigate(['/vendorDashboard']);
    }, (error) => {
      console.log('Error logging in:', error);
      alert('Invalid credentials');
    });
  }

  onLogout() {
    localStorage.removeItem('token');
    this.serviceService.setisloggedIn(false);
  }
}
