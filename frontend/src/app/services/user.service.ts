import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../models/user';
import { UserDto } from '../models/user-dto';
import { Observable } from 'rxjs';
import { GLOBAL_CONFIG } from '../config/config.global';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private entity = 'users/dto';

  constructor(private http: HttpClient
  ) { 

  }

  getAll(): Observable<UserDto[]>{
    const url = `${GLOBAL_CONFIG.apiBaseUrl}users/dto`;
    console.log(url);
    return this.http.get<UserDto[]>(url);
  }

  delete(id:number){
    const url = `${GLOBAL_CONFIG.apiBaseUrl}users/${id}`;
    console.log(url);
    return this.http.delete(url);
  }
}
