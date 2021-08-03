import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseDetailComponent } from '../course-detail/course-detail.component';
import { HomeComponent } from './home.component';

const routes: Routes = [{path : '' , component : HomeComponent , 
children : [
  {path : 'courses' , loadChildren : () => import('../courses/courses.module').then(m => m.CoursesModule)},
  {path : 'courses/:id' , component : CourseDetailComponent},
  {path : 'home' , loadChildren : () => import('../courses/courses.module')}
]}]; 

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
