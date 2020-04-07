import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
  styles:[]
})
export class UserComponent implements OnInit {

  constructor(public service:UserService) { }

  ngOnInit(): void {
  }


  resetForm(form?:NgForm)
  {
    if(form!=null)
    {
      form.resetForm();
      this.service.formData = {
        Id: null,
        UserName: null,
        Password: null,
        Email: null,
        Active: 0
      }
    }
  }

  onSubmit(form:NgForm)
  {
    this.service.postUser(form.value).subscribe(
      res => {
        this.resetForm(form)
      },
      err => {
        console.log(err)
      }
    )
  }
}
