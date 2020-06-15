import { Component, OnInit } from '@angular/core';
import { ShiftService } from 'src/app/shared/shifts/shift.service';
import { TradeComponent } from 'src/app/pages/trade/trade.component';
import { TradeService } from 'src/app/shared/trades/trade.service';
import {  CommonModule } from '@angular/common'
import { NgForm } from '@angular/forms';
import { Trade } from 'src/app/shared/trades/trade.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-trade-create',
  templateUrl: './trade-create.component.html',
  styleUrls: ['./trade-create.component.css']
})
export class TradeCreateComponent implements OnInit {

  constructor(public shiftService: ShiftService, public tradeService: TradeService,private toastr: ToastrService, private router: Router) { }
  
  ngOnInit(): void {
    this.shiftService.getRosterFree();
    this.shiftService.getRoster();
  }

  onSubmit(form:NgForm)
  {
    var trade = form.value as Trade;
    console.log(trade);
    this.tradeService.createTrade(trade).subscribe(
      res => {
        this.resetForm(form)
        this.toastr.success('Submitted successfully', 'User Created')
        this.router.navigateByUrl('profile');
      },
      err => {
        console.log(err)
      }
    )
  }

  resetForm(form?:NgForm)
  {
    if(form!=null)
    {
      form.resetForm();
      this.tradeService.trade = {
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
    }
  }

}
