import { Injectable } from '@angular/core';
import { Roster } from './roster.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RosterService {

  rosterData: Roster={
    UserId: null,
    ShiftId: null,
    Shifts: null
  }

  readonly rootURL = "http://localhost:50271/api";

  constructor(private http:HttpClient) { }

  refreshRoster(){
    this.http.get(this.rootURL+'/roster')
    .toPromise()
    .then(res => this.rosterData = res as Roster)
  }
}
