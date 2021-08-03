import { Component, OnInit } from '@angular/core';
import { Assignment } from './assignment';

@Component({
  selector: 'app-day19',
  templateUrl: './day19.component.html',
  styleUrls: ['./day19.component.css']
})
export class Day19Component implements OnInit {

  constructor() { }

  ngOnInit(): void {
    Assignment();
  }

}
