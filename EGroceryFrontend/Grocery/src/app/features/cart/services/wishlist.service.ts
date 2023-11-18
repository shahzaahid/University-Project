import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WishlistService {

  constructor(private http: HttpClient) {}

  getWishlistItems(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`http://localhost:5148/api/WishList/GetWishListItemsByWishListId?wishListId=${userId}`);
  }

  deleteData(wishListId:number,productId: number): Observable<any> {
    return this.http.delete<any>(`http://localhost:5148/api/WishList/wishlist/${wishListId}/product/${productId}`);
  }
}
