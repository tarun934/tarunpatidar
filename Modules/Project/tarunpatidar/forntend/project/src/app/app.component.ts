import { Component, OnInit } from '@angular/core';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'project';
  public token : any;

  ngOnInit(): void {
    console.log(this.token);
  }

  constructor(private logService : LoginService){}
}