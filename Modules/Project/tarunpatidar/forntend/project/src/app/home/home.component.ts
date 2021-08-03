import { Component, Input, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  @Input ('parentData') public token : any;

  constructor(private logService : LoginService) { }

  ngOnInit(): void {
  }

  isUserLoggedIn(){
    return this.logService.loggedIn();
  }

  logOutUser(){
    this.logService.logoutUser();
  }

}