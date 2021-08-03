import { Component, OnInit } from '@angular/core';
import { FormBuilder , Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CoursesService } from '../services/courses.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  seracheCourses : any;
  allCourses : any;
  Courses : any;

  constructor(private fb : FormBuilder , private courses : CoursesService , private route : Router) { }

  searchForm = this.fb.group({
    cors : ['' , [Validators.required , Validators.minLength(10)]],
  });

  ngOnInit(): void {

    this.courses.getAllCourses().subscribe(
      res => {
        this.allCourses = res;
        console.log(res);
        console.log(this.allCourses)
      },
      err=>console.log(err)
    )
  }

  SearchCourses(){
    var cors = this.searchForm.get('Cors') !.value;
    if(cors != ''){
      this.courses.searchCourses(cors).subscribe(
        (res : any)=>{
          if(res.length == 0){
            alert("Not Found");
          }
          else{
            this.allCourses = res;
            console.log(res)
          }
        }
      );
    }

    else{
      this.courses.getAllCourses().subscribe(
        res=>{
          this.allCourses = res;
          console.log(res);
          console.log(this.allCourses)
        },
        err=>console.log(err)
      )
    }
  }
}