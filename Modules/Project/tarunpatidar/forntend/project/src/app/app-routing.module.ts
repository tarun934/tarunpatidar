import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { RegisterComponent } from './register/register.component';
import { LogGuard } from './services/log.guard';

const routes: Routes = [
  {path : 'login' , component : LoginComponent},
  {path : 'register' , component : RegisterComponent},
  {
    canActivate : [LogGuard]
  },

  {path : "**" , component : PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
