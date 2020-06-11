import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/shared/users/user.model';
import { UserService } from 'src/app/shared/users/user.service';
import { ShiftService } from 'src/app/shared/shifts/shift.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  constructor(public router: Router, private toastr: ToastrService, public userService: UserService, public shiftService: ShiftService) { }

  public currentUser: User = JSON.parse(localStorage.getItem('currentUser'));

  ngOnInit(): void {
    console.log(this.currentUser);
    this.shiftService.getRoster();
  }


  
}
