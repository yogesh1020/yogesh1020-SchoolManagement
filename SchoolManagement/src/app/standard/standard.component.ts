import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SchoolService } from '../school.service';

@Component({
  selector: 'app-standard',
  templateUrl: './standard.component.html',
  styleUrls: ['./standard.component.css']
})
export class StandardComponent implements OnInit {
  standardFormGroup:FormGroup
  standardName: any;
  constructor( private formBuilder:FormBuilder , private school:SchoolService) { }

  ngOnInit(): void {
    this.standardFormGroup=this.formBuilder.group({
      stuId:['',Validators.required],
      name:['',Validators.required]
    })
  }
  standard(event:any){
  this.standardName = event.target.value 
}
stdData = this.standardFormGroup.value + this.standardName
  submit(){
    this.school.addStandard(this.stdData)
  }

}
