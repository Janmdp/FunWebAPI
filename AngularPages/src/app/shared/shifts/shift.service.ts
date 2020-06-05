import { Injectable } from '@angular/core';
import { Shift } from './shift.model';
import { HttpClient } from '@angular/common/http';

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

  constructor(private http:HttpClient) { }

  refreshList(){
    this.http.get(this.rootURL+'/shift')
    .toPromise()
    .then(res => this.shiftList = res as Shift[])
  }
}
