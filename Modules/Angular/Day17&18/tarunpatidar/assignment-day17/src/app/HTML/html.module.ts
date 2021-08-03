import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HtmlRoutingModule } from './html-routing.module';
import { Day3Component } from './day3/day3.component';
import { HtmlComponent } from './html/html.component';


@NgModule({
  declarations: [
    Day3Component,
    HtmlComponent
  ],
  imports: [
    CommonModule,
    HtmlRoutingModule
  ]
})
export class HtmlModule { }
