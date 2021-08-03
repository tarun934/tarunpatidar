import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {

  private baseUrl = environment.baseUrl;

  constructor(private http : HttpClient) { }

  getAllCourses(){
    return this.http.get(this.baseUrl + '/Home/allCourses');
  }

  getCourses(corsid : number){
    return this.http.get(this.baseUrl + '/Home/courses/' + corsid);
  }

  searchCourses(Cors : string){
    return this.http.get(`${this.baseUrl}/Home/SearchCourses/${Cors}`);
  }
}