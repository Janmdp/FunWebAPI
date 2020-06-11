import { Component, OnInit } from '@angular/core';
import { ShiftService } from 'src/app/shared/shifts/shift.service';

@Component({
  selector: 'app-shift-list',
  templateUrl: './shift-list.component.html',
  styleUrls: ['./shift-list.component.css']
})
export class ShiftListComponent implements OnInit {

  constructor(public shiftService: ShiftService) { }

  ngOnInit(): void {
  }

}
