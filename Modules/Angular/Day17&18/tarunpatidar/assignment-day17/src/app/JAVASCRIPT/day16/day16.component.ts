import { Component, OnInit } from '@angular/core';
import { Assignment } from './assignment';

@Component({
  selector: 'app-day16',
  templateUrl: './day16.component.html',
  styleUrls: ['./day16.component.css']
})
export class Day16Component implements OnInit {

  constructor() { }

  ngOnInit(): void {
    Assignment();
  }

}
