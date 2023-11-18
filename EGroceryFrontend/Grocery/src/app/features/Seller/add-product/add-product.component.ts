import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ServiceService } from '../dataSharing/vendor-service.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  form!: FormGroup;
  vendorId: number = 0;
  imageName: string = '';

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router,
    private serviceService: ServiceService
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      brand: [''],
      category: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required],
      unit: ['', Validators.required],
      packSize: ['', Validators.required],
      stockQty: ['', Validators.required]
    });

    this.serviceService.vendorId$.subscribe(vendorId => {
      this.vendorId = vendorId;
      console.log('Vendor ID from Service:', this.vendorId);
    });
  }

  onSubmit() {
    const productDetails = {
      name: this.form.value.name,
      brand: this.form.value.brand,
      category: this.form.value.category,
      description: this.form.value.description,
      price: this.form.value.price,
      unit: this.form.value.unit,
      packSize: this.form.value.packSize,
      stockQty: this.form.value.stockQty,
      vendorId: this.vendorId,
      addedBy: this.vendorId
    };

    this.http.post('http://localhost:5148/api/Product', productDetails).subscribe(
      (response: any) => {
        this.imageName = response;
        console.log("response is "+this.imageName);
        this.uploadProductImage(response);
      },
      (error) => {
        console.log(error);
        alert('Error registering.');
      }
    );
  }

  uploadProductImage(productId:number) {
    const inputElement = document.getElementById('productImage') as HTMLInputElement;
    const file = inputElement?.files?.[0];

    if (file) {
      const formData = new FormData();
      formData.append('image', file);

      this.http.post(`http://localhost:5148/api/Product/UploadImage?userId=${productId}`, formData).subscribe(
        (response: any) => {
          alert('Product Added Successfully');
          this.router.navigate(['/vendorDashboard']);
        },
        (error) => {
          console.error(error);
          alert('Error uploading the image.');
        }
      );
    }
  }

  onFileChange(event: Event): void {
    // Handle file change logic if needed
  }
}
