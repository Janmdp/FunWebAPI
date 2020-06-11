import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onLogout(){
    localStorage.removeItem('currentUser');
    this.router.navigateByUrl('');
    this.toastr.success('Succesfully logged out', 'Logout');
  }

  onProfile(){
    this.router.navigateByUrl('profile');
  }

  
}
