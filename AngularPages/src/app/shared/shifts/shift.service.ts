import { Injectable } from '@angular/core';
import { Shift } from './shift.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../users/user.model';

@Injectable({
  providedIn: 'root'
})
export class ShiftService {
  shiftData: Shift={
    ShiftId: null,
    Start: null,
    End: null
  }

  readonly rootURL = "http://localhost:50271/api";

  shiftList: Shift[];
  roster: Shift[];
  rosterFree: Shift[];
  constructor(private http:HttpClient) { }

  getRoster(){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    this.http.get(this.rootURL+'/roster?Id=' + user.UserId, { headers : tokenHeader} )
    .toPromise()
    .then(res => {
      this.roster = res as Shift[];
      //console.log(res);
      //console.log(this.roster);
    })
  }

  getRosterFree(){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    this.http.get(this.rootURL+'/shift/free?Id=' + user.UserId, { headers : tokenHeader} )
    .toPromise()
    .then(res => {
      this.rosterFree = res as Shift[];
      console.log(res);
      console.log(this.rosterFree);
    })
  }

  
  refreshList(){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    this.http.get(this.rootURL+'/shift' + user.UserId, { headers : tokenHeader} )
    .toPromise()
    .then(res => {
    this.shiftList = res as Shift[];
      //console.log(res);
      //console.log(this.roster);
    })
  }
}
