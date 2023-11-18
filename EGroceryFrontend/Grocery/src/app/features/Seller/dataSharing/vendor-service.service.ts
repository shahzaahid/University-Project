import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  private vendorIdSubject = new BehaviorSubject<number>(0);
  vendorId$ = this.vendorIdSubject.asObservable();

  setVendorId(vendorId: number): void {
    this.vendorIdSubject.next(vendorId);
  }
  private productIdSubject = new BehaviorSubject<number>(0);
  productId$ = this.productIdSubject.asObservable();

  setproductId(productId: number): void {
    this.productIdSubject.next(productId);
  }
  private isloggedInSubject = new BehaviorSubject<boolean>(false);
  isloggedIn$ = this.isloggedInSubject.asObservable();

  setisloggedIn(isloggedIn: boolean): void {
    this.isloggedInSubject.next(isloggedIn);
  }
}
