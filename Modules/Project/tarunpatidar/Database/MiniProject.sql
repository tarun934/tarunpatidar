use MiniProject
go

create table Courses
(

  CourseID int primary key,
  CourseName Varchar (50),
  CourseType Varchar (50),
  CourseDescription Varchar (50)

)

create table Student 
(

  StuID int primary key,
  StuName Varchar (50),
  StuMobile Varchar (20),
  StuEmail Varchar (25),
  StuAddress Varchar (50),

)

create table Fees
(

  CrsFeeID int primary key,
  CrsFeeDecription Varchar (50),
  CrsFeeType Varchar (50)

)

create table Schedule
(

  SchID int primary key,
  SchName Varchar (50),
  SchTime Varchar (20),
  SchDate Date,
  SchDescription Varchar (50)

)