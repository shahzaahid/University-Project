import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataSharingService } from 'src/app/features/Data-Sharing Service/data-sharing.service';
import { CartService } from '../../services/cart.service';
import { forkJoin } from 'rxjs';
import { Router } from '@angular/router';
import { response } from 'express';
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  address: any=0;
  userId = 0;
  cartItems: any[] = [];
  productQuantities: any;
  subTotal: number = 0;
  products: any[] = [];
  userDetails:any=0;
  orderDetails={};
  customerName="";
  currentMonth: string="";
  removeId:any;
  constructor(
    private http: HttpClient,
    private DataSharingService: DataSharingService,
    private cartService: CartService,
    private router :Router
  ) {}

  ngOnInit(): void {
    this.DataSharingService.userId$.subscribe(UserId => {
      this.userId = UserId;
      console.log('UserId:', this.userId);
      this.loadAddressDetails();
      this.loadCartItems();
      this.loadUserDetails();
      this.currentMonth = new Date().toLocaleString('default', { month: 'long' });
    });
  }

  loadAddressDetails() {
    this.http.get(`http://localhost:5148/api/User/GetUserAddressById/${this.userId}`)
      .subscribe(
        (response: any) => {
          if (response && response.length > 0) {
            this.address = response[0];
            console.log("Address details:", this.address);
          } else {
            // Handle empty response or other cases
          }
        },
        (error: any) => {
          console.error('API Error:', error);
          // Handle errors here
        }
      );
  }

  loadCartItems(): void {
    const userId = this.userId; // Replace with the actual user ID or fetch it dynamically
    this.cartService.getCartItems(userId).subscribe(
      (data) => {
        this.cartItems = data;
        const productIds = this.cartItems.map(item => item.productId);
        this.productQuantities = {}; // Dictionary to store product quantities
        this.removeId = [];
        console.log("cart items is  "+this.cartItems)
        for (const item of this.cartItems) {          
          const productId = item.productId;
          this.removeId.push(productId);
          const quantity = parseInt(item.quantity);
          this.productQuantities[productId] = quantity; // Store quantity for each product
          this.subTotal = this.cartItems.reduce((total, item) => {
            return total + item.totalAmount;
          }, 0);
        }
  
        console.log("Product quantities:", this.productQuantities);
  
        if (productIds.length === 0) {
          // Reset products array to empty if there are no items in the cart
          this.products = [];
        } else {
          // Load product details only if there are items in the cart
          this.loadProductDetails(productIds);
        }
      },
      (error) => {
        console.error('Error fetching cart items:', error);
      }
    );
  }
  
  loadProductDetails(productIds: number[]): void {
    const apiUrl = 'http://localhost:5148/api/Product'; // Replace with your API endpoint URL
    const productRequests = productIds.map(productId => this.http.get(`${apiUrl}/${productId}`));

    forkJoin(productRequests).subscribe(
      (data: any[]) => {
        this.products = data;
        console.log('Products:', this.products);
      },
      (error) => {
        console.error('Error fetching product details:', error);
      }
    );
  }
  loadUserDetails() {
    this.http.get(`http://localhost:5148/api/User/${this.userId}`)
      .subscribe(
        (response: any) => {
          if (response && response.length > 0) {
            this.userDetails = response[0];
            console.log("User details:", this.address);
          } else {
            // Handle empty response or other cases
          }
          console.log("user details"+this.userDetails)
        },
        (error: any) => {
          console.error('API Error:', error);
          // Handle errors here
        }
      );
  }

  placeorder() {
    if (this.userId === 0) {
      alert("Login first");
      this.router.navigate(['/login']);
    } else if (this.address === 0) {
      alert("Give Your Address Details First");
      this.router.navigate(['/AddAddress']);
    } else if (!this.cartItems || this.cartItems.length === 0) {
      alert("No Items In Cart");
      this.router.navigate(['/product-list']);
    } else {
      const orderDetail = {
        customerId: this.userId,
        customerName: this.userDetails.firstName+" "+this.userDetails.lastName, // Replace with the actual property name from userDetails
        address: this.address.address, // Replace with the actual property name from address
        state: this.address.state, // Replace with the actual property name from address
        totalAmount: this.subTotal,
        status: 'Pending',
        month: this.currentMonth,
      };
      console.log(this.userId,this.userDetails.name,this.address.address,this.address.state,this.subTotal)

      this.http.post('http://localhost:5148/api/Order', orderDetail).subscribe(
        (response: any) => {
          this.removeFromCart();
          alert("Order Placed Successfully");
          this.router.navigate(['/']);
        },
        (error: any) => {
          alert("Order Placed Unsuccessfully");
        }
      );
    }
  }
  removeFromCart(): void {
    console.log("remove ids are: " + this.removeId);
    for (let id of this.removeId) {
        this.http.delete(`http://localhost:5148/api/Cart/DeleteCartItem?id=${id}`).subscribe(
            (response: any) => {
                // Handle success response here if needed
            },
            (error: any) => {
                // Handle error response here if needed
            }
        );
    }
}

}
