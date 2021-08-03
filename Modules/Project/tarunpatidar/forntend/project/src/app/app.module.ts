import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LogGuard } from './services/log.guard';
import { TokenService } from './services/token.service';
import { HTTP_INTERCEPTORS , HttpClientModule } from '@angular/common/http';
import { CoursesModule } from './courses/courses.module';
import { LoginService } from './services/login.service';
import { CourseDetailComponent } from './course-detail/course-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    CourseDetailComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    CoursesModule,
    HttpClientModule
  ],
  providers: [LogGuard, LoginService,
  {
    provide : HTTP_INTERCEPTORS,
    useClass : TokenService,
    multi : true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
