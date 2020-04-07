import { Injectable } from '@angular/core';
import { User } from './user.model';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {
formData:User = {
  Id: null,
  UserName: null,
  Password: null,
  Email: null,
  Active: 0
}
readonly rootURL = "http://localhost:50271/api";
  constructor(private http:HttpClient) { }

  postUser(formData:User){
  return this.http.post(this.rootURL+'/user',formData)
  }
}
