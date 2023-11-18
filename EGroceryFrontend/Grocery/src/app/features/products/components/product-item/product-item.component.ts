import { Component,OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { HttpClient } from '@angular/common/http'; 
@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent {
  selectedProductId: number;
  productData: any;
  constructor(
    private productService: ProductService,
    private http: HttpClient // Inject HttpClient
  ) {
    this.selectedProductId = this.productService.getSelectedProductId();
  }
  ngOnInit() {
    // Make a GET request to fetch product data
    this.http.get('http://localhost:5148/api/Product/' + this.selectedProductId)
      .subscribe((data) => {
         this.productData=data;
        console.log(this.productData); // You can handle the fetched data here
        //}
      });
  }
  addToCart(product: any) {
    // Implement the logic to add the product to the cart here
  }
   // Method to increase the quantity of an item
increaseQuantity(index: number) {
  if (this.productData[index].quantity >= 1) {
    this.productData[index].quantity++; // Increase quantity
    this.productData[index].totalAmount += this.productData[index].price; // Add the price to the total amount
  }
}

// Method to decrease the quantity of an item
decreaseQuantity(index: number) {
  if (this.productData[index].quantity > 1) {
    this.productData[index].quantity--; // Decrease quantity
    this.productData[index].totalAmount -= this.productData[index].price; // Subtract the price from the total amount
  }
}


  // Method to update the total amount for an item
  // updateTotalAmount(index: number) {
  //   this.productData[index].totalAmount = this.productData[index].quantity * this.productData[index].price;
  // }

  // Method to remove an item from the wishlist
  removeItem(index: number) {
    this.productData.splice(index, 1);
  }
}
