import { Injectable } from '@angular/core';
import { Trade } from './trade.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../users/user.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

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
trade: Trade = {
  TradeId: null,
    Shift: null,
    ReworkShift: null,
    RequestUser: null,
    AcceptUser: null,
    ShiftId: null,
    ReworkShiftId: null,
    RequestUserId: null,
    AcceptUserId: null
}

  constructor(private http:HttpClient, private toastr: ToastrService, private router: Router) { }

  refreshList(){
    console.log('pepega');
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    this.http.get(this.rootURL+'/trade/all?Id='+user.UserId, { headers : tokenHeader})
    .toPromise()
    .then(res => this.tradeList = res as Trade[]);
    
  }

  acceptTrade(Id: number){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});

    this.tradeList.forEach(tr => {
      if(tr.TradeId == Id)
      {
        tr.AcceptUser = user;
        console.log(tr);
        return this.http.put(this.rootURL+'/trade', tr, { headers : tokenHeader}).subscribe(
          res => {
            this.refreshList();
            this.toastr.success('Submitted successfully', 'User Created');
            this.router.navigateByUrl('trades');
          },
          err => {
            console.log(err)
          }
        );
      }
    });
  }

  createTrade(newTrade: Trade){
    var user: User = JSON.parse(localStorage.getItem('currentUser'));
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' + user.Token});
    newTrade.RequestUser = user;
    newTrade.RequestUserId = user.UserId;
    newTrade.ReworkShiftId = newTrade.ReworkShift.ShiftId;
    newTrade.ShiftId = newTrade.Shift.ShiftId;
    return this.http.post(this.rootURL+'/trade', newTrade, { headers : tokenHeader} )
  }

}
