import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class DataSharingServiceService {

  constructor() { }
  private orderDetailSubject = new BehaviorSubject<object>({}); // Initial value is an empty object
  orderDetail$ = this.orderDetailSubject.asObservable();

  setorderDetail(orderDetail: object): void {
    // Perform your asynchronous operation (HTTP request, etc.) here if needed
    this.orderDetailSubject.next(orderDetail);
  }

}
