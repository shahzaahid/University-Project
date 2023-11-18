import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { forkJoin } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { DataSharingService } from 'src/app/features/Data-Sharing Service/data-sharing.service';
import { DataSharingServiceService } from '../../services/data-sharing-service.service';
@Component({
  selector: 'app-cart-items-list',
  templateUrl: './cart-items-list.component.html',
  styleUrls: ['./cart-items-list.component.css']
})
export class CartItemsListComponent implements OnInit {
  cartItems: any[] = [];
  products: any[] = [];
  productQuantities :any;
  subTotal:number=0;
  userId:number=0;
  constructor(private cartService: CartService,
     private http: HttpClient,
     private DataSharingService:DataSharingService,
     private DataSharingServiceService:DataSharingServiceService
     ) {}

  ngOnInit(): void {
      this.DataSharingService.userId$.subscribe(UserId => {
        this.userId = UserId;
        console.log('User ID from Service:', this.userId);
        this.loadCartItems(); // Load CartItems items after userId is available
      });
    }

  loadCartItems(): void {
    const userId = this.userId; // Replace with the actual user ID or fetch it dynamically
    this.cartService.getCartItems(userId).subscribe(
      (data) => {
        this.cartItems = data;
        const productIds = this.cartItems.map(item => item.productId);
        this.productQuantities = {}; // Dictionary to store product quantities
  
        for (const item of this.cartItems) {
          const productId = item.productId;
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

  // Function to decrease the quantity for a specific row
  decreaseQuantity(quantity: number, product: any): void {
    const currentQuantity = this.productQuantities[product.id];
    const newQuantity = currentQuantity-1;
  
    const details = {
      cartId: this.userId,
      productId: product.id,
      quantity: newQuantity,
      totalAmount: product.price*newQuantity
    };
  
    console.log("Details before sending to updateCartItem:", details);
  
    if (newQuantity >=1 ) {
      this.updateCartItem(this.userId,product.id, details);
    } else {
      window.alert("Quantity Can't Be 0");
    }
  }
  
  increaseQuantity(quantity: number, product: any): void {
    const currentQuantity = this.productQuantities[product.id];
    const newQuantity = currentQuantity+1;
  
    const details = {
      cartId: this.userId,
      productId: product.id,
      quantity: newQuantity,
      totalAmount: product.price*newQuantity
    };
  
    console.log("Details before sending to updateCartItem:", details);
  
    if (newQuantity <= product.stockQty) {
      this.updateCartItem(this.userId,product.id, details);
    } else {
      window.alert("Out of stock");
    }
  }
  
  updateCartItem(cartId:number,productId:number,details: any): void {
    this.cartService.updateCartItem(cartId,productId,details).subscribe(
      () => {
        console.log('Cart item updated successfully');
        // Refresh the Cart after updating the item
        this.loadCartItems();
      },
      (error:any) => {
        console.error('Error updating Cart item', error);
      }
    );
  }
 
  // Function to update the total price for a specific row
  updateTotalPrice(row: any): void {
    // Implement your logic to update total price if needed
  }

  // Function to remove product from cart
  removeFromCart(index: number): void {
    this.cartService.removeItem(index).subscribe(
      (data) => {
        alert("Item deleted");
        this.loadCartItems();
      },
      (error) => {
        console.error("Error deleting item:", error);
        // Handle error as needed
      }
    );
  }

  // Function to add item save for later
  addToWishlist(product: any) {
    const wishlistdata = {
      wishListId: this.userId,
      totalAmount: product.price,
      quantity: product.packSize,
      productId: product.id
  };

    console.log(wishlistdata);
    this.cartService.WishlistAdded(wishlistdata).subscribe(
      (data: any) => {
        // Check if the response contains an 'error' property
        product.inWishlist = true;
        console.log('Product added to wishlist:', data);
        window.alert('Item Added To Wishlist');
      },
      (error: any) => {
        console.error('Error adding product to wishlist:', error);
        window.alert('Error adding item to wishlist');
      }
    );
  }

}

