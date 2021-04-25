import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user';
import { UserDetails } from 'src/app/models/userDetails';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService){}

  getAllUsers() : Observable<User[]>{
    return this.apiService.getAll('user');
  }

  getUserById(id: number) : Observable<UserDetails>{
    return this.apiService.getDetails(`${'user'}`,id);
  }
}
