import { Injectable } from '@angular/core';
import { Trade } from './trade.model';
import { HttpClient } from '@angular/common/http';

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
    this.http.get(this.rootURL+'/trade')
    .toPromise()
    .then(res => this.tradeList = res as Trade[])
  }

}
