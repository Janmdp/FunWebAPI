import { Injectable } from '@angular/core';
import { Trade } from './trade.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../users/user.model';

@Injectable({
  providedIn: 'root'
})
export class TradeService {

tradeData: Trade={
TradeId: null,
Shift: null,
ReworkShift: null,
RequestUser: null,
AcceptUser: null,
ShiftId: null,
ReworkShiftId: null,
RequestUserId: null,
AcceptUserId: null,
}

readonly rootURL = "http://localhost:50271/api";

tradeList: Trade[];

  constructor(private http:HttpClient) { }

  refreshList(){
    console.log('pepega');
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    this.http.get(this.rootURL+'/trade/all', { headers : tokenHeader})
    .toPromise()
    .then(res => this.tradeList = res as Trade[]);
    
  }

}
