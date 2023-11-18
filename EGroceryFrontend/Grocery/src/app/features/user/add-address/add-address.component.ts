import { Component, OnInit } from '@angular/core';
import { DataSharingService } from 'src/app/features/Data-Sharing Service/data-sharing.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.css']
})
export class AddAddressComponent implements OnInit {
  userId = 0;
  form: FormGroup;

  constructor(
    private http: HttpClient,
    private DataSharingService: DataSharingService,
    private router: Router,
    private formBuilder: FormBuilder // Inject FormBuilder
  ) {
    // Initialize the form in the constructor
    this.form = this.formBuilder.group({
      addressType: ['', Validators.required],
      address: ['', Validators.required],
      teshsil: [''],
      district: [''],
      postOffice: [''],
      pincode: ['', Validators.required],
      state: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.DataSharingService.userId$.subscribe(UserId => {
      this.userId = UserId;
      console.log('UserId:', this.userId);
    });
  }
  onSubmit() {
    if (this.userId === 0) {
      alert("Login First");
    } else {
      const addressDetails = {
        userId: this.userId,
        addressType: this.form.value.addressType,
        address: this.form.value.address,
        tehsil: this.form.value.teshsil,
        district: this.form.value.district,
        postOffice: this.form.value.postOffice,
        pincode: this.form.value.pincode,
        state: this.form.value.state
      };
      console.log(addressDetails)
      this.http.post('http://localhost:5148/api/User/AddUserAddress', addressDetails)
        .subscribe(
          (response: any) => {
            alert('Address added successfully');
            this.router.navigate(['/userDashboard']);
          },
          (error) => {
            console.log(error);
            alert('Error registering.');
          }
        );
    }
  }
}
