import { Component, OnInit } from '@angular/core';
import { ProductService } from '../products/services/product.service';
import { DataSharingService } from '../Data-Sharing Service/data-sharing.service';

@Component({
  selector: 'app-category',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  products: any[] = [];
  search: string = ''; // Initialize category variable
  search2:string='';
  constructor(
    private productService: ProductService,
    private dataSharingService: DataSharingService
  ) {}

  ngOnInit() {
    this.dataSharingService.searchValue$.subscribe(search => {
      this.search = search; // Update the category variable when the observable emits a new value
      this.search2 = this.search + 's'
      console.log('search:', this.search); // Log the updated category value
    });

    this.productService.getProducts().subscribe(
      (data: any) => {
        // Initialize products with the wishlist status
        this.products = data.map((product: any) => ({
          ...product,
          inWishlist: false // Assuming none of the products are in the wishlist initially
        }));
        console.log(this.products);
      },
      (error: any) => {
        console.error('Error fetching products:', error);
        // Handle the error here, e.g., show an error message to the user
      }
    );
  }
  onEyeIconClick(productId: number) {
    this.productService.setSelectedProductId(productId);
  }

  addToCart(product: any) {
    // Implement the logic to add the product to the cart here
    const data = {
      cartId: 1, // Assuming a hard-coded customer ID for now
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
  

  addToWishlist(product: any) {
    const wishlistdata = {
      wishListId: 1,
      totalAmount: product.price,
      quantity: 1,
      productId: product.id
  };

    console.log(wishlistdata);
    this.productService.WishlistAdded(wishlistdata).subscribe(
      (data: any) => {
        // Check if the response contains an 'error' property
        console.log('Product added to wishlist:', data);
        window.alert('Item Added To Wishlist');
      },
      (error: any) => {
        console.error('Error adding product to wishlist:', error);
        window.alert('Error adding item to wishlist');
      }
    );
  }
  Category(cat: string): void {
    this.dataSharingService.setCategory(cat);
  }
}
