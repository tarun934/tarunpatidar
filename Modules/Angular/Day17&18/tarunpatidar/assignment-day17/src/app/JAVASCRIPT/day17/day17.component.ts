import { Component, OnInit } from '@angular/core';
import { details } from './details';

@Component({
  selector: 'app-day17',
  templateUrl: './day17.component.html',
  styleUrls: ['./day17.component.css']
})
export class Day17Component implements OnInit {

  constructor() { }

  ngOnInit(): void {
    details();
  }

}
