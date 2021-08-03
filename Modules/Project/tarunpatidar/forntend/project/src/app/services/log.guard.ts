import { Injectable } from "@angular/core";
import { CanActivate , Router } from '@angular/router';

import { LoginService } from "./login.service";

@Injectable({
    providedIn : 'root'
})

export class LogGuard implements CanActivate {
    constructor(private _logService : LoginService , private route : Router){ }

    canActivate() : boolean{
        if (this._logService.loggedIn()){
            return true
        }
        else{
            this.route.navigate(['login']);
            return false;
        }
    }
}