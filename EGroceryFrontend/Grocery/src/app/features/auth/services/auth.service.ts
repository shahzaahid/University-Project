import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private backendUrl = 'http://localhost:5148/api'; // Update this to your .NET backend base URL

  constructor(private http: HttpClient) { }

  login(emailaddress: string, password:string) {
    const loginData = { emailaddress, password };
    return this.http.post(`${this.backendUrl}/Login`, loginData);
    
  }
}
