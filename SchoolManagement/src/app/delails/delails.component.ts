import { Component, OnInit } from '@angular/core';
import { SchoolService } from '../school.service';

@Component({
  selector: 'app-delails',
  templateUrl: './delails.component.html',
  styleUrls: ['./delails.component.css']
})
export class DelailsComponent implements OnInit {
  studentData: any;

  constructor(private school:SchoolService) { 
      school.details().subscribe((data :any)=> this.studentData = data);
  }

  ngOnInit(): void {
  }

}
