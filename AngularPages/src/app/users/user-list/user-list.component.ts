import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/users/user.service';
import { User } from 'src/app/shared/users/user.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  styles:[]
})
export class UserListComponent implements OnInit {

  constructor(public service: UserService,
    public toastr: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.service.refreshList();
  }


  populateForm(us: User){
    this.service.formData = Object.assign({}, us);
  }

  onDelete(UserId){
    if(confirm('Are you sure you want to delete this user?')){
      this.service.deleteUser(UserId)
      .subscribe(res =>{
      this.service.refreshList();
      this.toastr.warning('Deleted Successfully');
    },
      err =>{
      console.log(err);
    })
    }

  }

  onLogout(){
    localStorage.removeItem('currentUser');
    this.router.navigateByUrl('');
    this.toastr.success('Succesfully logged out', 'Logout');
  }
}
