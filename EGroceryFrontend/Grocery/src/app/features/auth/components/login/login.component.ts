

import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder,Validators } from '@angular/forms';
import { DataSharingService } from 'src/app/features/Data-Sharing Service/data-sharing.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 // Add this line to your component
hidePassword: boolean = true;
wishlistData:object={};
cartData:object={};
userId:number=0;
form!: FormGroup;
// Modify the togglePasswordVisibility function
togglePasswordVisibility(): void {
    this.hidePassword = !this.hidePassword;
}

  constructor(
    private fb: FormBuilder,
     private http: HttpClient,
      private router: Router,
      protected DataSharingService :DataSharingService,
    ) {  }

  ngOnInit() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
    const storedToken = localStorage.getItem('token');
    if (storedToken) {
      this.DataSharingService.setuserLoggedIn(true);
    }
  }
  
  onSubmit() {
    const loginRequest = {
      email: this.form.value.email,
      password: this.form.value.password
    };
   console.log(loginRequest);
    this.http.post('http://localhost:5148/api/Login/user', loginRequest).subscribe((response: any) => {
      // Handle the response here as text
      this.DataSharingService.setuserId(response.userId);
      this.userId=response.userId;
      localStorage.setItem('token', response.token);
      alert("Login successful")
      this.createWishlist();
      this.form.reset(); // Reset the form
      this.router.navigate(['/']);
    }, (error) => {
      
      console.log('Error logging in:', error);
      alert('Invalid credentials');
    });
  }
  createWishlist() {
    console.log('Creating Wishlist...'); // Add this line
    this.wishlistData = {
      id:this.userId,
      customerId: this.userId,
      wishlistId: this.userId
    };
    console.log('Wishlist Data:', this.wishlistData); // Add this line
    this.http.post('http://localhost:5148/api/WishList', this.wishlistData).subscribe(
      (response: any) => {
        console.log('Wishlist Created:', response); // Add this line
      },
      (error) => {
        console.error('Error creating wishlist:', error); // Add this line
      }
    );
  }
  
  // createCart()
  // {
  //   this.cartData={
  //     customerId:this.userId,
  //     cartId:this.userId
  //   }
  //   this.http.post('http://localhost:5148/api/Cart',this. cartData).subscribe((response: any) => {
  //   }, (error) => {
  //   });
  // }
  onLogout() {
    localStorage.removeItem('token');
    this.DataSharingService.setuserLoggedIn(false);
  }
}

