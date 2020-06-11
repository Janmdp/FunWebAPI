import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/shared/users/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/users/user.model';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.css']
})
export class UserUpdateComponent implements OnInit {

  constructor(public service:UserService,
    public toastr: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.populateForm();
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

  populateForm(){
    this.service.getUser().subscribe(
      (res: any) => {
        console.log(res);
        this.service.profile = Object.assign({}, res);
        this.service.profile.Password = null;
        console.log(this.service.profile);
      },
      err => {
        if(err.status == 400)
        {
          this.toastr.error('something went wrong', 'Authentication failed');
        }
        else
        {
          console.log(err)
        }
      }
    )
    
  }

  onSubmit(form:NgForm)
  {
    var test = form.value as User;
    test.UserId = this.service.profile.UserId;
    this.service.updateUser(test).subscribe(
      res => {
        this.resetForm(form)
        this.toastr.success('Submitted successfully', 'User Update')
        this.router.navigateByUrl('profile');
      },
      err => {
        console.log(err)
      }
    )
  }

}
