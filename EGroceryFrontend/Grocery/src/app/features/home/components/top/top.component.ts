import { Component } from '@angular/core';
import * as feather from 'feather-icons';
import { DataSharingService } from 'src/app/features/Data-Sharing Service/data-sharing.service';
@Component({
  selector: 'app-top',
  templateUrl: './top.component.html',
  styleUrls: ['./top.component.css']
})
export class TopComponent {
  searchValue:any;
  constructor(private dataSharingService: DataSharingService) {
  }
  onSearchClick(): void {
    // Handle the search button click event
    this.dataSharingService.setSearchValue(this.searchValue); // Log the search value to the console
    // You can use this.searchValue to pass the value to an API, perform a search operation, etc.
  }
  Category(cat: string): void {
    this.dataSharingService.setCategory(cat);
  }
  ngAfterViewInit() {
    feather.replace();
  }

 
}
