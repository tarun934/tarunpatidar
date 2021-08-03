import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CssModule } from './CSS/css.module';
import { HtmlModule } from './HTML/html.module';
import { JavascriptModule } from './JAVASCRIPT/javascript.module';

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CssModule,
    HtmlModule,
    JavascriptModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
