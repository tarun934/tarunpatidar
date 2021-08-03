import { Component, OnInit } from '@angular/core';
import {FormBuilder,Validators} from '@angular/forms';
import { Router } from '@angular/router';
import {LoginService} from '../services/login.service';
import { PasswordValidator } from '../validator/password.validators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private fb : FormBuilder,private _log : LoginService, private route : Router) { }

  registrationForm = this.fb.group({
    Username: ['',[Validators.required,Validators.minLength(3)]],
    FullName : ['',Validators.required],
    Email : ['',[Validators.required,Validators.email]],
    Password : ['',[Validators.required,PasswordValidator]] 
  });
  ngOnInit(): void {
  }

  get userName(){
    return this.registrationForm.get('Username')!;
  }
  get fullName(){
    return this.registrationForm.get('FullName')!;
  }
  get email(){
    return this.registrationForm.get('Email')!;
  }
  get password(){
    return this.registrationForm.get('Password')!;
  }

  registerUser(){
    //debugger;
    this._log.registerUser(this.registrationForm.value)
    .subscribe(
      res => {
        if(res.status == "Success"){
          alert (res.message);
          this.route.navigate(['login']);
        }
        else{
          alert(res.message)
        }
      },
        err=>alert(err.error.message)
      )
    }

  loginUser(){
    this.route.navigate(['login']);
  }
}
