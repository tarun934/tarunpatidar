import { Component, OnInit } from '@angular/core';
import { Assignment } from './assignment';

@Component({
  selector: 'app-day15',
  templateUrl: './day15.component.html',
  styleUrls: ['./day15.component.css']
})
export class Day15Component implements OnInit {

  constructor() { }

  ngOnInit(): void {
    Assignment();
  }

}
