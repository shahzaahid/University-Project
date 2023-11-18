import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './features/home/components/homepage/homepage.component';
import { WishlistComponent } from './features/cart/components/wishlist/wishlist.component';
import { ProductComponent } from './features/products/components/product/product.component';
import { ProductListComponent } from './features/products/components/product-list/product-list.component';
import { CartItemsListComponent } from './features/cart/components/cart-items-list/cart-items-list.component';
import { CheckoutComponent } from './features/cart/components/checkout/checkout.component';
import { ContactComponent} from './features/contact/contact.component';
import { AboutComponent } from './features/about/about.component';
import { LoginComponent } from './features/auth/components/login/login.component';
import { SignupComponent } from './features/auth/components/signup/signup.component';
import { ForgetComponent } from './features/auth/components/forget/forget.component';
import { ProductItemComponent } from './features/products/components/product-item/product-item.component';
import { CategoryComponent } from './category/category.component';
import { SearchComponent } from './features/search/search.component';
import { VendorComponent } from './features/Seller/vendor-login/vendor.component';
import { AddVendorComponent } from './features/Seller/add-vendor/add-vendor.component';
import { AddProductComponent } from './features/Seller/add-product/add-product.component';
import { VendorDashboardComponent } from './features/Seller/vendor-dashboard/vendor-dashboard.component';
import { CdkVirtualScrollableWindow } from '@angular/cdk/scrolling';
import { EditProductComponent } from './features/Seller/edit-product/edit-product.component';
import { EditVendorComponent } from './features/Seller/edit-vendor/edit-vendor.component';
import { AddAddressComponent } from './features/user/add-address/add-address.component';
import { UserDashboardComponent } from './features/user/user-dashboard/user-dashboard.component';
import { EditAddressComponent } from './features/user/edit-address/edit-address.component';
const routes: Routes = [
  {
    path: "",
    component: HomepageComponent
  },
  {
    path: "wishlist",
    component: WishlistComponent
  },
  { 
    path:"product",
     component: ProductComponent
  },
  {
     path:"product-list", 
     component: ProductListComponent
  },
  {
    path: "cartitemslist",
    component: CartItemsListComponent
  },
  {
    path: "checkout",
    component: CheckoutComponent
  },
  {
    path: "contact",
    component: ContactComponent
  },
  {
    path: "about",
    component: AboutComponent
  },
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "signup",
    component: SignupComponent
  },
  {
    path: "forget",
    component: ForgetComponent
  },
  {
    path:"productItem",
    component:ProductItemComponent
  },
  {
    path:"category",
    component:CategoryComponent
  },
  {
    path:"search",
    component:SearchComponent
  },
  {
    path:"vendor",
    component:VendorComponent
  },
  {
    path:"addVendor",
    component:AddVendorComponent
  },
  {
    path:"addProduct",
    component:AddProductComponent
  },
  {
    path:"vendorDashboard",
    component:VendorDashboardComponent
  },
  {
    path:"editProduct",
    component:EditProductComponent
  },
  {
    path:"EditVendor",
    component:EditVendorComponent
  },
  {
    path:"AddAddress",
    component:AddAddressComponent
  },
  {
    path:"userDashboard",
    component:UserDashboardComponent
  },
  {
    path:"editAddress",
    component:EditAddressComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
