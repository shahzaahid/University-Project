import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { DataSharingService } from 'src/app/features/Data-Sharing Service/data-sharing.service';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: any[] = [];
  userId:number=0;
  startProduct=0;
  lastProduct=20;
  totalProduct=0;
  constructor(private productService: ProductService,private dataSharingService: DataSharingService) {}

  ngOnInit() {
    this.productService.getProducts().subscribe(
      (data: any) => {
        // Initialize products with the wishlist status
        this.products = data.map((product: any) => ({
          ...product,
          inWishlist: false // Assuming none of the products are in the wishlist initially
        }));
        console.log(this.products);
        for(let p of this.products)
        {
          this.totalProduct=this.totalProduct+1;
        }
      },
      (error: any) => {
        console.error('Error fetching products:', error);
        // Handle the error here, e.g., show an error message to the user
      }
    );
    this.dataSharingService.userId$.subscribe(UserId => {
      this.userId = UserId;
      console.log('User ID from Service:', this.userId);
    });
  }
  onEyeIconClick(productId: number) {
    this.productService.setSelectedProductId(productId);
  }

  addToCart(product: any) {
    if(this.userId !==0)
    {
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
    else{
      alert("Login First");
    }
  }
  

  addToWishlist(product: any) {
    if(this.userId !== 0){
    const wishlistdata = {
      wishListId: this.userId,
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
        // window.alert('Error adding item to wishlist');
        
      }
    );
    }
    else{
      alert("Login First");
    }
  }
  Category(cat: string): void {
    this.dataSharingService.setCategory(cat);
  }

  nextPage()
  {
    if(this.lastProduct>this.totalProduct)
    {

    }
    else{
    this.startProduct=this.lastProduct;
    console.log("start product is "+this.startProduct); 
    this.lastProduct=this.lastProduct+20;
    }
  }
  prevPage()
  {
    if(this.lastProduct===20)
    {

    }
    else{
      this.lastProduct= this.startProduct;   
      this.startProduct= this.startProduct-20;
    }
   
  }
}
