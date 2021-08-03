import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private _baseUrl = environment.baseUrl;

  isLoggedIn : boolean = false;

  constructor(private http : HttpClient , private route : Router) { }

  registerUser(user : any){
    return this.http.post<any>(`${this._baseUrl}/authenticate/register` , user);
  }

  loginUser(user : any){
    return this.http.post(`${this._baseUrl}/authenticate/login` , user);
  }

  loggedIn(){
    return !! localStorage.getItem('token');
  }

  logoutUser(){
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    this.route.navigate(['']);
  }

  getToken(){
    return localStorage.getItem('token');
  }
}
