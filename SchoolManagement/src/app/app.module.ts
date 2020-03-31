import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';
import { StandardComponent } from './standard/standard.component';
import { InstallmentComponent } from './installment/installment.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DelailsComponent } from './delails/delails.component';
import { AddmitionComponent } from './addmition/addmition.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    StandardComponent,
    InstallmentComponent,
    DelailsComponent,
    AddmitionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
