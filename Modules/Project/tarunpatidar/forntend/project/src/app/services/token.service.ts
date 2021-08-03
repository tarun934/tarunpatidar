import { Injectable , Injector } from '@angular/core';
import { HttpInterceptor} from '@angular/common/http';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class TokenService implements HttpInterceptor {

  constructor(private injector : Injector) { }

  intercept(req : any , next : any){
    let logService = this.injector.get(LoginService);
    let tokenizeReq = req.clone({
      setHeaders : {
        Login : `Bearer ${logService.getToken()}`
      }
    });
    return next.handle(tokenizeReq);
  }
}