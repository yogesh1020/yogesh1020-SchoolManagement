import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentComponent } from './student/student.component';
import { StandardComponent } from './standard/standard.component';
import { InstallmentComponent } from './installment/installment.component';
import { DelailsComponent } from './delails/delails.component';


const routes: Routes = [
  {
    path:'student' , component:StudentComponent
  },
  {
    path:'standerd' , component:StandardComponent
  },
  {
    path :'installment' , component:InstallmentComponent
  },
  {
    path:'delails', component:DelailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
