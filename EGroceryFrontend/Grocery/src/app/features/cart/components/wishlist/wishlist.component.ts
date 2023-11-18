import { Component, OnInit } from '@angular/core';
import { WishlistService } from 'src/app/features/cart/services/wishlist.service';
import { HttpClient } from '@angular/common/http';
import { forkJoin } from 'rxjs';
import { ProductService } from 'src/app/features/products/services/product.service';
import { DataSharingService } from 'src/app/features/Data-Sharing Service/data-sharing.service';
@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css'],
})
export class WishlistComponent implements OnInit {
  wishlistItems: any[] = [];
  products: any[] = [];
  productIds: number[] = [];
  userId:number=0;
  constructor(
    private wishlistService: WishlistService, 
    private http: HttpClient,
    private productService: ProductService,
    private DataSharingService :DataSharingService
    ) {}
    ngOnInit(): void {
      this.DataSharingService.userId$.subscribe(UserId => {
        this.userId = UserId;
        console.log('User ID from Service:', this.userId);
        this.loadWishlistItems(); // Load wishlist items after userId is available
      });
    }
    

  loadWishlistItems(): void {
    this.wishlistService.getWishlistItems(this.userId).subscribe(
      (data) => {
        this.wishlistItems = data;
        console.log(this.wishlistItems); 
        // Extract productIds and convert them to integers in a single statement
        this.productIds = this.wishlistItems.map(item => item.productId);
  
        if (this.productIds.length === 0) {
          // Reset products array to empty if there are no items in the wishlist
          this.products = [];
        } else {
          // Load product details only if there are items in the wishlist
          this.loadProductDetails(this.productIds);
        }
  
        console.log("product id is :" + this.productIds);
      },
      (error) => {
        console.error('Error fetching wishlist items:', error);
        // Handle error gracefully, show user-friendly error message
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

 
  removeFromWishlist(productId: number): void {
    this.wishlistService.deleteData(this.userId,productId).subscribe(
      (data) => {
        alert("Item deleted");
        // Fetch the updated wishlist items after deleting the item
        this.loadWishlistItems();
        if (this.wishlistItems.length === 0) {
          // Reset the products array to an empty array
          this.products = [];
        }
      },
      (error) => {
        console.error("Error deleting item:", error);
        // Handle error as needed
      }
    );
  }

  addToCart(product: any) {
    // Implement the logic to add the product to the cart here
    const data = {
      cartId: this.userId, // Assuming a hard-coded customer ID for now
      totalAmount: product.price,
      productId:product.id,
      quantity: 1
    };
    this.productService.CartAdded(data).subscribe(
      (data: any) => {
        // Check if the response contains an 'error' property
        product.inWishlist = true;
        console.log('Product added to Cart:', data);
        window.alert('Item Added To Cart');

        // Update products in local storage
        localStorage.setItem('products', JSON.stringify(this.products));
      },
      (error: any) => {
        console.error('Error adding product to Cart:', error);
        window.alert('Error adding item to Cart');
      }
    );
  }

  
}
