import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServiceService } from '../dataSharing/vendor-service.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';
@Component({
  selector: 'app-vendor-dashboard',
  templateUrl: './vendor-dashboard.component.html',
  styleUrls: ['./vendor-dashboard.component.css']
})
export class VendorDashboardComponent implements OnInit, OnDestroy {
  profileData: any;
  products: any[] = [];
  vendorId: number = 0;
  totalProducts=0;
  myProducts=0;
  private unsubscribe$: Subject<void> = new Subject<void>();

  constructor(
    private http: HttpClient,
    private ServiceService: ServiceService,
    private router: Router
  ) {}

  ngOnInit() {
    this.ServiceService.vendorId$.pipe(takeUntil(this.unsubscribe$)).subscribe(vendorId => {
      this.vendorId = vendorId;
      console.log('Vendor ID from Service:', this.vendorId);
      this.fetchVendorDetails();
    });
    this.fetchProducts();
  }

  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  fetchVendorDetails() {
    this.http.get(`http://localhost:5148/api/Vendor/GetVendorById?id=${this.vendorId}`).subscribe(response => {
      this.profileData = response;
      // Do something with the fetched vendor data
    });
  }

  fetchProducts() {
    this.http.get(`http://localhost:5148/api/Product`).subscribe(
      (data: any) => {
        this.products = data;
        console.log(this.products);
        for(let p of this.products)
        {
          this.totalProducts=this.totalProducts+1;
          if(p.vendorId===this.vendorId)
          {
            this.myProducts=this.myProducts+1;
          }
        }
      },
      (error: any) => {
        console.error('Error fetching products:', error);
        // Handle the error here, e.g., show an error message to the user
      }
    );
  }

  deleteProduct(id: number): void {
    console.log(id);
    this.http.delete(`http://localhost:5148/api/Product/${id}`).subscribe(
      () => {
        console.log(`Product with ID ${id} deleted successfully.`);
        alert("Deleted Successfully")
        this.fetchProducts(); // Update the product list after successful deletion
      },
      (error: any) => {
        alert("error deleting the product")
        console.error('Error deleting product:', error);
        // Handle the error here, e.g., show an error message to the user
      }
    );
  }
  editId(id:number)
  {
    this.ServiceService.setproductId(id);
    this.router.navigate(['/editProduct']);
  }
  onLogout() {
    localStorage.removeItem('token');
    this.ServiceService.setisloggedIn(false);
    this.router.navigate(['/vendor']);
  }
}
