import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SuccessDialogComponent } from '../modals/success-dialog/success-dialog.component';
import { FailureDialogComponent } from '../modals/failure-dialog/failure-dialog.component';

import { RentDTO } from '../models/rent-dto.model';
import { RentService } from '../services/rent.service';
import { CarService } from '../services/car.service';


@Component({
  selector: 'app-list-rent',
  templateUrl: './list-rent.component.html',
  styleUrl: './list-rent.component.css'
})
export class ListRentComponent implements OnInit{

  rents:RentDTO[] = []

  constructor(private rentService: RentService,
              private carService: CarService,
              private dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.getAllRentsWithFullData();   
  }

  deleteRent(id: number, idCar:number){
    this.rentService.delete(id).subscribe({
      next: (data) => {
        this.carUpdateRented(idCar, 0);
        this.getAllRentsWithFullData();
        console.log('Rent deleted successfully.');
        this.dialog.open(SuccessDialogComponent, {
          data: {
            message: 'Rent deleted successfully!'
          }
        });

      },
      error: (error) => {
        console.error('Error deleting customer: ', error);
        if (error.error && error.error.errors) {
          console.error('Error\'s details from validation:', error.error.errors);
        }
      }
    })
  }

  carUpdateRented(id:number, rented:number){
    this.carService.updateRented(id, rented).subscribe({
      next: (data) => {
        console.log('Car\'s state updating successfully: ', data);
      },
      error: (error) => {
        console.error('Error updating Car\'s state: ', error);
      }
    })
  }

  getAllRentsWithFullData(): any{
    this.rentService.getAll().subscribe({
      next: (data:RentDTO[]) => {
        this.rents = data;
      },
      error: (error) => {
        console.error('Error listing customers: ', error);
        if (error.error && error.error.errors) {
          console.error('Error\'s detailss from validation: ', error.error.errors);
        }
      }
    });
  }
}
