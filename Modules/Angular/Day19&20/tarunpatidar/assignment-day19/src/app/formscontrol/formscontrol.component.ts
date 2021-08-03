import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormArray,FormGroup, Validators, FormControl} from '@angular/forms';
import {Validator} from '../validator';
import {Student} from '../Istudent';


@Component({
  selector: 'app-formscontrol',
  templateUrl: './formscontrol.component.html',
  styleUrls: ['./formscontrol.component.css']
})
export class FormscontrolComponent implements OnInit {

  student :Array<Student>=[];

  StudentForm!:FormGroup;

  constructor(private Form: FormBuilder){
    
  }




ngOnInit(){
  this.StudentForm= this.Form.group({
    Name : this.Form.group({
      FirstName:['',Validators.required],
      MiddleName:['',Validators.required],
      LastName: ['',Validators.required]
    }),
    DOB : ['',[Validators.required,Validator]],
    PlaceOfBirth:['',Validators.required],
    FirstLanguage:['',Validators.required],
    Address:this.Form.group({
      City : ['',Validators.required],
      State:['',Validators.required],
      Pin : ['',[Validators.required, Validators.pattern(/^\d{6}$/)]]
    }),
    Father : this.Form.group({
      Name : this.Form.group({
        FirstName : ['',Validators.required],
      MiddleName : ['',Validators.required],
      LastName : ['',Validators.required]
      }),
      Email : ['',[Validators.required,Validators.email]],
      EducationQualification : [''],
      Profession : [''],
      Designation : [''],
      Phone : ['',[Validators.required,Validators.pattern(/^\d{10}$/)]],
    }),
    
  
    Mother : this.Form.group({
        Name : this.Form.group({
        FirstName : [''],
        MiddleName : [''],
        LastName : ['']
      }),
      Email : ['',Validators.email],
      EducationQualification : [''],
      Profession : [''],
      Designation : [''],
      Phone : ['',Validators.pattern(/^\d{10}$/)],
    }),
    EmergencyContactList: this.Form.array([
      this.Form.group({
        Relation : ['',Validators.required],
        Number : ['',[Validators.required,Validators.pattern(/^\d{10}$/)]]
      })
    ]),
    ReferenceDetails : this.Form.group({
      ReferenceThrough : [''],
      Address : this.Form.group({
        City : [''],
        TelNo : ['',Validators.pattern(/^\d{10}$/)]
      })
    })
  });
  
}
studentArray : Array<Student>=[];





  get getEmergencyContactList(){
    return this.StudentForm.get('EmergencyContactList') as FormArray;
  }
  

AddList(){
  this.getEmergencyContactList.push(this.Form.group({
    Relation : [''],
    Number : ['']
  }));
}



//Student
get getStudentFirstName(){
  
  return this.StudentForm.controls.Name.get('FirstName');
}
get getStudentMiddleName(){
  
  return this.StudentForm.controls.Name.get('MiddleName');
}
get getStudentLastName(){
  
  return this.StudentForm.controls.Name.get('LastName');
}
get getStudentDoB(){
  return this.StudentForm.get('DOB');
}
get getPlaceOfBirth(){
  return this.StudentForm.get('PlaceOfBirth');
}

get getStudentCity(){
  return this.StudentForm.controls.Address.get('City');
}

get getStudentState(){
  return this.StudentForm.controls.Address.get('State');
}

get getStudentPinCode(){
  return this.StudentForm.controls.Address.get('Pin');
}

//Father

get getFatherFirstName(){
  
  return this.StudentForm.controls.Father.get('Name')?.get('FirstName');
}
get getFatherMiddleName(){
  
  return this.StudentForm.controls.Father.get('Name')?.get('MiddleName');
}
get getFatherLastName(){
  
  return this.StudentForm.controls.Father.get('Name')?.get('LastName');
}
get getFatherEmail(){
  return this.StudentForm.controls.Father.get('Email');
}

get getFatherPhone(){
  return this.StudentForm.controls.Father.get('Phone');
}

// Mother
get getMotherFirstName(){
  
  return this.StudentForm.controls.Mother.get('Name')?.get('FirstName');
}
get getMotherMiddleName(){
  
  return this.StudentForm.controls.Mother.get('Name')?.get('MiddleName');
}
get getMotherLastName(){
  
  return this.StudentForm.controls.Mother.get('Name')?.get('LastName');
}

get getMotherEmail(){
  return this.StudentForm.controls.Mother.get('Email');
}

get getMotherPhone(){
  return this.StudentForm.controls.Mother.get('Phone');
}


//Reference Details

get referenceTelNo(){
  return this.StudentForm.controls.ReferenceDetails.get('Address')?.get('TelNo');
}

LoadData(){
  this.StudentForm.patchValue(this.student);
}

Submit(){
  this.studentArray.push(this.StudentForm.value);
  console.log(this.studentArray);
  
  
}

}
