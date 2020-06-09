import { Injectable } from '@angular/core';
import { User } from './user.model';
import { HttpClient, HttpHeaderResponse, HttpHeaders } from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})
export class UserService {
formData:User = {
  UserId: null,
  Username: null,
  Password: null,
  Email: null,
  Active: 0,
  Token: null
}
private CurrentUser: User ={
  UserId: null,
  Username: null,
  Password: null,
  Email: null,
  Active: 0,
  Token: null
}

readonly rootURL = "http://localhost:50271/api";

list :User[];

  constructor(private http:HttpClient) { }

  postUser(formData:User){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
  return this.http.post(this.rootURL+'/user',formData, {headers : tokenHeader})
  }

  tryLogin(formData:User){
    
    return this.http.post(this.rootURL+'/login',formData);
    }

  refreshList(){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    this.http.get(this.rootURL+'/user', { headers : tokenHeader})
    .toPromise()
    .then(res => this.list = res as User[])
  }

  deleteUser(id){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    return this.http.delete(this.rootURL+'/user?Id='+ id, {headers : tokenHeader});
  }
}
