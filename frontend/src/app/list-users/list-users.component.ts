import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { SuccessDialogComponent } from '../modals/success-dialog/success-dialog.component';
import { FailureDialogComponent } from '../modals/failure-dialog/failure-dialog.component';
import { UserDto } from '../models/user-dto';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrl: './list-users.component.css'
})
export class ListUsersComponent implements OnInit {

  users: UserDto[] = [];

  constructor(private userService: UserService,
              private dialog: MatDialog) {

  }

  ngOnInit(){
    this.getAllUsers();
  }

  getAllUsers(){
    this.userService.getAll().subscribe({
      next: (data: UserDto[]) => {
        this.users = data;
      },
      error: (error) => {
        console.error('Error getting users.', error);

        this.dialog.open(FailureDialogComponent, {
          data: {
            message: 'Error getting users!'
          }
        });
      }
    });   
  }

  deleteUser(id:number){
    this.userService.delete(id).subscribe({
      next: (data) => {
        console.log('User deleted successfully.');

        this.getAllUsers();
        this.dialog.open(SuccessDialogComponent, {
          data: {
            message: 'User deleted successfully!'
          }
        });

      },
      error: (error) => {
        console.error('Error deleting users.', error);

        this.dialog.open(FailureDialogComponent, {
          data: {
            message: 'Error deleting users.!'
          }
        });

      }
    });  
  }

  isAdmin(id:number){
    return id == 2;
  }

  getMessage(){
    this.dialog.open(FailureDialogComponent, {
      data: {
        message: 'Can\'t delete this user!'
      }
    });
  }

}
