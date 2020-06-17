import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/users/user.service';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/shared/users/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  styles:[]
})
export class LoginComponent implements OnInit {

  constructor(public service:UserService,
    public toastr: ToastrService,
    private router: Router) { }
  
  ngOnInit(): void {
    if(localStorage.getItem('currentUser')!= null){
      this.router.navigateByUrl('/home');
    }
  }

  currentUser: User ={
    UserId: null,
    Username: null,
    Password: null,
    Email: null,
    Active: 0,
    Token: null
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

  tryLogin(form:NgForm)
  {
    this.service.tryLogin(form.value).subscribe(
      (res: any) => {
        this.currentUser = res as User;
        localStorage.setItem("currentUser", JSON.stringify(this.currentUser));
        this.resetForm(form);
        this.toastr.success('Login successfull', 'Login');
        this.router.navigateByUrl('/home');
      },
      err => {
        if(err.status == 400)
        {
          this.toastr.error('Incorrect username or password', 'Authentication failed');
        }
        else
        {
          console.log(err)
        }
      }
    )
  }
}
