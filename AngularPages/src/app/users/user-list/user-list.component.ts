import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/users/user.service';
import { User } from 'src/app/shared/users/user.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  styles:[]
})
export class UserListComponent implements OnInit {

  constructor(public service: UserService,
    public toastr: ToastrService) { }

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
}
