import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class SchoolService {
  headers: HttpHeaders;
  stuUrl: string = 'https://localhost:44307/api/Students';
  stdUrl:string='https://localhost:44307/api/Standards';
  detailsUrl = 'https://localhost:44307/api/VStudentDetails';
  installmentUrl = 'https://localhost:44307/api/VStudentDetails';
  
  addmitionUrl = 'https://localhost:44307/api/Addmitions';
  constructor(private http:HttpClient) { 
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'})
  }

  public addStudent(stuData){
  return  this.http.post(this.stuUrl,JSON.stringify(stuData),{headers:this.headers});
  }
  public addStandard(stdData){
    return this.http.post(this.stdUrl,JSON.stringify(stdData),{headers:this.headers});
  }
  public details(){
   return this.http.get(this.detailsUrl,{headers:this.headers});
  }
  public installment(installmentData){
    return this.http.post(this.installmentUrl,installmentData,{headers:this.headers})
  }
  public addmition(addmitionData){
    return this.http.post(this.addmitionUrl,addmitionData,{headers:this.headers})
  }
}
