import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-trade',
  templateUrl: './trade.component.html',
  styleUrls: ['./trade.component.css']
})
export class TradeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  myTrades(){
    this.router.navigateByUrl("mytrades")
  }
}
