import { Component, OnInit } from '@angular/core';
import { TradeService } from 'src/app/shared/trades/trade.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-trade-list',
  templateUrl: './trade-list.component.html',
  styleUrls: ['./trade-list.component.css']
})
export class TradeListComponent implements OnInit {

  constructor(public tradeService: TradeService) { }

  ngOnInit(): void {
    this.tradeService.refreshList();
  }

  acceptTrade(Id: number){
    console.log(Id);
    this.tradeService.acceptTrade(Id);
  }
}
