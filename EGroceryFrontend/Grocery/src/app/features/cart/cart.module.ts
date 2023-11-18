import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SummaryComponent } from './components/summary/summary.component';
import { EmptyComponent } from './components/empty/empty.component';
import { CodesComponent } from './components/codes/codes.component';
import { CheckoutComponent } from './components/checkout/checkout.component';


@NgModule({
  declarations: [
    SummaryComponent,
    EmptyComponent,
    CodesComponent,
    
  ],
  imports: [
    CommonModule
  ]
})
export class CartModule { }
