import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ServiceService } from '../dataSharing/vendor-service.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {
 form!: FormGroup;
 productId:number=0;
 vendorId=0;
 product:any;
 private unsubscribe$: Subject<void> = new Subject<void>();
  constructor(
    private fb: FormBuilder, 
    private http: HttpClient, 
    private router: Router,
    private ServiceService: ServiceService
    ) { }

    ngOnInit() {
      this.ServiceService.vendorId$.pipe(takeUntil(this.unsubscribe$)).subscribe(vendorId => {
        this.vendorId = vendorId;
      });
    
      this.ServiceService.productId$.pipe(takeUntil(this.unsubscribe$)).subscribe(productId => {
        this.productId = productId;
        console.log("product id is " + this.productId);
        this.fetchProductDetails(); // Fetch product details after getting productId
      });
    
      // Initialize the form with default values
      this.form = this.fb.group({
        name: [''], // Set the default name here
        brand: [''],
        category: [''],
        description: [''],
        price: [''],
        unit: [''],
        packSize: [''],
        stockQty: [''],
      });
    }

  onSubmit() {

    const registerRequest = {
      id:this.productId,
      name: this.form.value.name,
      brand: this.form.value.brand,
      category: this.form.value.category,
      description: this.form.value.description,
      price: this.form.value.price,
      unit: this.form.value.unit,
      packSize: this.form.value.packSize,
      stockQty: 1,
      vendorId: this.vendorId,
      addedBy:this.vendorId,
    };
console.log(registerRequest)
    this.http.put( `http://localhost:5148/api/Product/${this.productId}`, registerRequest).subscribe((response: any) => {
      this.productId=response;
      alert('Product Edited successfull');
    }, (error) => {
      console.log(error);
      alert('Error registering.');
    });
  }
  onFileChange(event: Event): void {
    const inputElement = event.target as HTMLInputElement;
    const file = inputElement?.files?.[0];

    if (file) {
        // Client-side content type validation
        if (!file.type.startsWith('image/')) {
            alert('Invalid file format. Please upload an image.');
            return;
        }

        // Client-side file size validation (limit to 5MB for example)
        const maxSize = 5 * 1024 * 1024; // 5MB in bytes
        if (file.size > maxSize) {
            alert('File size exceeds the limit (5MB). Please upload a smaller image.');
            return;
        }

        // Show loading indicator if needed

        // Upload the file to the server
        const formData = new FormData();
        formData.append('image', file); // Use 'image' as the field name
        
        this.http.post(`http://localhost:5148/api/Product/UploadImage?userId=${ this.productId}`, formData).subscribe(
            (response: any) => {
                // Hide loading indicator if needed
                alert('Product Image Uploaded');
            },
            (error) => {
                // Hide loading indicator if needed
                console.error(error);
                alert('Error uploading the image.');
            }
        );
    }
  }
  fetchProductDetails() {
    this.http.get(`http://localhost:5148/api/Product/${this.productId}`).subscribe(response => {
      console.log(response);
      this.product = response;
      // Initialize form controls with fetched product data
      this.form = this.fb.group({
        name: [this.product.name || '', Validators.required],
        brand: [this.product.brand || ''],
        category: [this.product.category || '', Validators.required],
        description: [this.product.description || '', Validators.required],
        price: [this.product.price || '', Validators.required],
        unit: [this.product.unit || '', Validators.required],
        packSize: [this.product.packSize || '', Validators.required],
        stockQty: [this.product.stockQty || '', Validators.required],
      });
    });
  }
  

}






