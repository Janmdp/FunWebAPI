import { Injectable } from '@angular/core';
import { User } from './user.model';
import { HttpClient, HttpHeaderResponse, HttpHeaders } from "@angular/common/http";
import { ToastrService } from 'ngx-toastr';


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
login: User ={
  UserId: null,
  Username: null,
  Password: null,
  Email: null,
  Active: 0,
  Token: null
}

profile:User = {
  UserId: null,
  Username: null,
  Password: null,
  Email: null,
  Active: 0,
  Token: null,
}
confirmPassword: string;


readonly rootURL = "http://localhost:50271/api";

list :User[];

  constructor(private http:HttpClient) { }

  public getUser(){
    console.log('happens')
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    return this.http.get(this.rootURL+'/user?Id='+ user.UserId, { headers : tokenHeader})
  }

 public postUser(formData:User){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    return this.http.post(this.rootURL+'/user',formData, { headers : tokenHeader})
  }

 public tryLogin(login:User){
    
    return this.http.post(this.rootURL+'/login',login);
    }

 public refreshList(){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    this.http.get(this.rootURL+'/user', { headers : tokenHeader} )
    .toPromise()
    .then(res => {
      this.list = res as User[];
      console.log(res);
      console.log(this.list);
    })
  }

 public deleteUser(id){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    return this.http.delete(this.rootURL+'/user?Id='+ id, { headers : tokenHeader});
  }

 public updateUser(profile:User)
  {
      var user: User = JSON.parse(localStorage.getItem('currentUser'));
      var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
      return this.http.put(this.rootURL+'/user', profile, { headers : tokenHeader})
  }
}
