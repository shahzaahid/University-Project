import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataSharingService {
  private categorySubject = new BehaviorSubject<string>(''); // Initial value is an empty string
  category$ = this.categorySubject.asObservable();

  setCategory(category: string): void {
    // Perform your asynchronous operation (HTTP request, etc.) here if needed
    this.categorySubject.next(category);
  }

  private searchValueSubject = new BehaviorSubject<string>(''); // Initial value is an empty string
  searchValue$ = this.searchValueSubject.asObservable();

  setSearchValue(search: string): void {
    // Perform your asynchronous operation (HTTP request, etc.) here if needed
    this.searchValueSubject.next(search);
  }

  //user ID 
  private userIdSubject = new BehaviorSubject<number>(0); // Initial value is an empty number
  userId$ = this.userIdSubject.asObservable();

  setuserId(id: number): void {
    // Perform your asynchronous operation (HTTP request, etc.) here if needed
    this.userIdSubject.next(id);
  }
  private userLoggedInSubject = new BehaviorSubject<boolean>(false);
  userLoggedIn$ = this.userLoggedInSubject.asObservable();

  setuserLoggedIn(userLoggedIn: boolean): void {
    this.userLoggedInSubject.next(userLoggedIn);
  }
}
