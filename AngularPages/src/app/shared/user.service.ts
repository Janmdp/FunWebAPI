import { Injectable } from '@angular/core';
import { User } from './user.model';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import * as bcrypt from 'bcryptjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
formData:User = {
  UserId: null,
  Username: null,
  Password: null,
  Email: null,
  Active: 0
}

readonly rootURL = "http://localhost:50271/api";

list :User[];

  constructor(private http:HttpClient) { }

  postUser(formData:User){
  return this.http.post(this.rootURL+'/user',formData)
  }

  tryLogin(formData:User){
    return this.http.post(this.rootURL+'/login',formData)
    }

  refreshList(){
    this.http.get(this.rootURL+'/user')
    .toPromise()
    .then(res => this.list = res as User[])
  }

  deleteUser(id){
    return this.http.delete(this.rootURL+'/user?Id='+ id)
  }
}
