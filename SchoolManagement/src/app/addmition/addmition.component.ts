import { Component, OnInit } from '@angular/core';
import { FormGroup , FormBuilder} from '@angular/forms';
import { SchoolService } from '../school.service';

@Component({
  selector: 'app-addmition',
  templateUrl: './addmition.component.html',
  styleUrls: ['./addmition.component.css']
})
export class AddmitionComponent implements OnInit {
  addmitionFormGroup:FormGroup
  constructor(private formBuilder:FormBuilder , private school:SchoolService) { }

  ngOnInit(): void {
    this.addmitionFormGroup = this.formBuilder.group({
      stuId:[],
      stdID:[]
    })
  }
  addmitionData = this.addmitionFormGroup.value
  submit(){
    this.school.addmition(this.addmitionData)

  }
}
