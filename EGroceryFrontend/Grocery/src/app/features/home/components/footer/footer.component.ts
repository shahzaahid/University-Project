import { Component } from '@angular/core';
import { DataSharingService } from 'src/app/features/Data-Sharing Service/data-sharing.service';
@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {
  constructor(private dataSharingService: DataSharingService) {
  }
  Category(cat: string): void {
    this.dataSharingService.setCategory(cat);
  }
}
