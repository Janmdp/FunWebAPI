import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/user.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  styles:[]
})
export class LoginComponent implements OnInit {

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
        Active: 0
      }
    }
  }

  tryLogin(form:NgForm)
  {
    this.service.tryLogin(form.value).subscribe(
      res => {
        this.resetForm(form)
        this.toastr.success('Login successfull', 'Login')
        this.service.refreshList();
      },
      err => {
        console.log(err)
      }
    )
  }
}
