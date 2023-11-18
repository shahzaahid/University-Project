import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ProductItemComponent } from './components/product-item/product-item.component';
@NgModule({
  declarations: [ 
    ProductItemComponent  
  ],
  imports: [
    CommonModule,
    HttpClientModule,
  ],
  exports: [ // Add this line to export the component
  ProductItemComponent
]
})
export class ProductsModule { }
