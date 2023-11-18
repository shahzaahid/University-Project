import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ServiceService } from '../dataSharing/vendor-service.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-edit-vendor',
  templateUrl: './edit-vendor.component.html',
  styleUrls: ['./edit-vendor.component.css']
})
export class EditVendorComponent implements OnInit {
  form!: FormGroup;
  hidePassword: boolean = true;
  vendorId: number = 0;
  profileData: any;
  private unsubscribe$: Subject<void> = new Subject<void>();

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router,
    private ServiceService: ServiceService
  ) {}

  ngOnInit() {
    this.ServiceService.vendorId$.pipe(takeUntil(this.unsubscribe$)).subscribe(vendorId => {
      this.vendorId = vendorId;
      console.log('Vendor ID from Service:', this.vendorId);
      this.fetchVendorDetails(); // Fetch vendor details here
    });

    this.form = this.fb.group({
      companyName: ['', Validators.required],
      fssai: [''],
      gst: ['', Validators.required],
      phonenumber: ['', Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(10)])],
      email: ['', Validators.compose([Validators.required, Validators.email])],
      password: ['', Validators.required],
      termsAgreed: [false, Validators.requiredTrue]
    });

    // Populate form controls with profileData after fetching details
    this.fetchVendorDetails();
  }

  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  fetchVendorDetails() {
    this.http.get(`http://localhost:5148/api/Vendor/GetVendorById?id=${this.vendorId}`).subscribe(response => {
      console.log(response);
      this.profileData = response;
      // Populate form controls with default values
      this.form.patchValue({
        companyName: this.profileData.companyName,
        fssai: this.profileData.fssai,
        gst: this.profileData.gst,
        phonenumber: this.profileData.mobileNo,
        email: this.profileData.emailId,
        password: this.profileData.password
      });
    });
  }

  togglePasswordVisibility(): void {
    this.hidePassword = !this.hidePassword;
  }

  onSubmit() {
    const registerRequest = {
      id: this.vendorId,
      companyName: this.form.value.companyName,
      fssai: this.form.value.fssai,
      gst: this.form.value.gst,
      mobileNo: this.form.value.phonenumber,
      emailId: this.form.value.email,
      password: this.form.value.password
    };

    this.http.put(`http://localhost:5148/api/Vendor/UpdateVendor?id=${this.vendorId}`, registerRequest).subscribe(
      (response: any) => {
        alert('Vendor edited successfully');
        this.fetchVendorDetails();
        this.router.navigate(['/vendorDashboard']);
      },
      error => {
        console.log(error);
        alert('Error editing vendor.');
      }
    );
  }
}
