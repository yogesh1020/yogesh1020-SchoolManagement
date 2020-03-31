import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup , Validators} from '@angular/forms';
import { SchoolService } from '../school.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
studentFormGroup:FormGroup
  constructor(private formBuilder:FormBuilder , private school:SchoolService) { }

  ngOnInit(): void {
    this.studentFormGroup = this.formBuilder.group({
      name:['',Validators.required],
      dob:['',Validators.required],
      gender:['',Validators.required],
      address:['',Validators.required],
      mobile:['',Validators.required],
      email:['',Validators.required],
      std:['',Validators.required],
    })

  }
  stuData = this.studentFormGroup.value
  submit(){
    this.school.addStudent(this.stuData)
  }
  

}
