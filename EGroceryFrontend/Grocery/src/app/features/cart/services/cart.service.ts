import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService {

  constructor(private http: HttpClient) {}

  getCartItems(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`http://localhost:5148/api/Cart/GetCartItemsByCartId?cartId=${userId}`);
  }

  removeItem(id: number): Observable<any> {
    return this.http.delete<any>(`http://localhost:5148/api/Cart/DeleteCartItem?id=${id}`);
  }
  WishlistAdded(productData: any): Observable<any> {
    return this.http.post('http://localhost:5148/api/WishList/AddWishListItem', productData);
  }
  updateCartItem(CartId:number,productId:number,details: object): Observable<any> {
    const updateUrl = `http://localhost:5148/api/Cart/${CartId}/?productId=${productId}`;
    console.log(details);
    return this.http.put(updateUrl, details);
  }
}
