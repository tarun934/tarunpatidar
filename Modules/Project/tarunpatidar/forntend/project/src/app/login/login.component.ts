import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';


import {LoginService} from '../services/login.service';
import { PasswordValidator } from '../validator/password.validators';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public currentUserToken : any;
  public error : any;
  @Output() public childEvent = new EventEmitter();


  constructor(private fb : FormBuilder,private _log : LoginService,private route:Router) { }

  loginForm = this.fb.group({
    Username: ['',[Validators.required,Validators.minLength(3)]],
    Password : ['',[Validators.required,PasswordValidator]]
  });
  ngOnInit(): void {
  }

  get userName(){
    return this.loginForm.get('Username')!;
  }
  get password(){
    return this.loginForm.get('Password')!;
  }

  loginUser(){
    
    this._log.loginUser(this.loginForm.value)
      .subscribe(
        (res: any) => {
          if (res.token != undefined) {
            localStorage.setItem('token', res.token);
            localStorage.setItem('userId',res.user);
            alert("Login Successfully done");
            // console.log(res);
            // this.currentUserToken = res;
            // console.log(res.message);
            //console.log(res.token);
            this.route.navigate(['']);
              
          } else {
            alert("username or password incorrect!");
          }


        },

      );

      
    // if(this.currentUser.response.status == "Success"){
    //   this.route.navigate(['']);
    // }else{
    //   alert(this.error);
    // }
  }

  registerUser(){
    this.route.navigate(['register']);
  }

}
