import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styles:[]
})
export class UserComponent implements OnInit {

  constructor(public service:UserService) { }

  ngOnInit(): void {
  }

}
