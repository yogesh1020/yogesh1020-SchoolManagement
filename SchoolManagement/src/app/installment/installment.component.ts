import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SchoolService } from '../school.service';

@Component({
  selector: 'app-installment',
  templateUrl: './installment.component.html',
  styleUrls: ['./installment.component.css']
})
export class InstallmentComponent implements OnInit {
  feeFormGroup:FormGroup
  constructor( private formBuilder:FormBuilder , private school:SchoolService) { }

  ngOnInit(): void {
    this.feeFormGroup = this.formBuilder.group({
      name:['',Validators.required],
      stdId:['',Validators.required],
      stuId:['',Validators.required],
      amount:['',Validators.required]
    })
  }
  installmentDate = this.feeFormGroup.value
  submit(){
    this.school.installment(this.installmentDate)
  }

}
