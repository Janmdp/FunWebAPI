import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/users/user.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
  styles:[]
})
export class UserComponent implements OnInit {

  constructor(public service:UserService,
    public toastr: ToastrService) { }

  ngOnInit(): void {
  }


  resetForm(form?:NgForm)
  {
    if(form!=null)
    {
      form.resetForm();
      this.service.formData = {
        UserId: null,
        Username: null,
        Password: null,
        Email: null,
        Active: 0,
        Token: null
      }
    }
  }

  onSubmit(form:NgForm)
  {
    this.service.postUser(form.value).subscribe(
      res => {
        this.resetForm(form)
        this.toastr.success('Submitted successfully', 'User Creation')
        this.service.refreshList();
      },
      err => {
        console.log(err)
      }
    )
  }
}
