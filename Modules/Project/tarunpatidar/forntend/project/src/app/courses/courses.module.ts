import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoursesRoutingModule } from './courses-routing.module';
import { CoursesComponent } from './courses.component';
import { FormsModule , ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CoursesComponent
  ],
  imports: [
    CommonModule,
    CoursesRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class CoursesModule { }