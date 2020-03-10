import { Injectable } from '@angular/core';
import { User } from './user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
formData:User = {
  Id: null,
  UserName: null,
  Password: null
}
  constructor() { }
}
