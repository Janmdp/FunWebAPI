import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/shared/users/user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  constructor(public router: Router, private toastr: ToastrService) { }

  public currentUser: User = JSON.parse(localStorage.getItem('currentUser'));

  ngOnInit(): void {
    console.log(this.currentUser);
  }


  onLogout(){
    localStorage.removeItem('currentUser');
    this.router.navigateByUrl('');
    this.toastr.success('Succesfully logged out', 'Logout');
  }
}
