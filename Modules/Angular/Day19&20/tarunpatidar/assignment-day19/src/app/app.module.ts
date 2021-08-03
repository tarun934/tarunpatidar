import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormscontrolComponent } from './formscontrol/formscontrol.component';
import { StudentFormComponent } from './student-form/student-form.component';

@NgModule({
  declarations: [
    AppComponent,
    FormscontrolComponent,
    StudentFormComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
