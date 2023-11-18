import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';
import { DataSharingService } from '../../Data-Sharing Service/data-sharing.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit, OnDestroy {
  profileData: any = {}; // Initialize profileData as an empty object
  userId: number = 0;
  AddressData :any;
  private unsubscribe$: Subject<void> = new Subject<void>();
  constructor(
    private http: HttpClient,
    private router: Router,
    private DataSharingService: DataSharingService
  ) {}

  ngOnInit(): void {
    this.DataSharingService.userId$.subscribe(UserId => {
      this.userId = UserId;
      console.log('UserId:', this.userId);
      this.fetchUserDetails();
      this.fetchAddressDetails();
    });
  }

  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  fetchUserDetails() {
    this.http.get(`http://localhost:5148/api/User/${this.userId}`).subscribe(
      (response: any) => {
        this.profileData = response[0]; // Assuming the API response is an array with a single object
        console.log(this.profileData);
        // Do something with the fetched vendor data
      },
      (error) => {
        console.error('Error fetching user details:', error);
      }
    );
  }
  deleteProduct(): void {
    this.http.delete(`http://localhost:5148/api/User/${this.userId}`).subscribe(
      () => {
        alert("Deleted Successfully")
        
      },
      (error: any) => {
        alert("error deleting the User")
      }
    );
  }
  fetchAddressDetails() {
    this.http.get(`http://localhost:5148/api/User/GetUserAddressById/${this.userId}`).subscribe(
      (response: any) => {
        this.AddressData = response[0]; // Assuming the API response is an array with a single object
        console.log(this.profileData);
        // Do something with the fetched vendor data
      },
      (error) => {
        console.error('Error fetching user details:', error);
      }
    );
  }
  onLogout() {
    localStorage.removeItem('token');
    this.DataSharingService.setuserLoggedIn(false);
    this.router.navigate(['/login']);
  }
}

