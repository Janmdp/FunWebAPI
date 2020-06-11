import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/users/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/users/user.model';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  constructor(public service:UserService,
    public toastr: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
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

  onUpdate(){
    this.router.navigateByUrl('update');
  }
}
