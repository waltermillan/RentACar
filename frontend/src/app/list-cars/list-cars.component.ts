import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SuccessDialogComponent } from '../modals/success-dialog/success-dialog.component';

import { Car } from '../models/car.model';
import { CarService } from '../services/car.service';
import { CarPriceService } from '../services/car-price.service';
import { CarPrice } from '../models/carPrice.model';
import { FailureDialogComponent } from '../modals/failure-dialog/failure-dialog.component';

@Component({
  selector: 'app-list-car',
  templateUrl: './list-cars.component.html',
  styleUrl: './list-cars.component.css'
})
export class ListCarsComponent {

  cars: Car[] = [];
  carprice:CarPrice[] = [];

  constructor(private carService: CarService, 
              private carPriceService: CarPriceService,
              private dialog:MatDialog) { 
  }

  ngOnInit(): void {
    this.getAllCars();
    this.getAllCarByIdWithPrice();
  }

  getAllCarByIdWithPrice():any{
    this.carPriceService.GetAllCarsWithPrice().subscribe({
      next: (data: CarPrice[]) => {
        this.carprice = data;
      },
      error: (error) => {
        console.error('Error getting cars with prices', error);
      }
    }); 
  }

  getAllCars(){
    this.carService.getAll().subscribe({
      next: (data: Car[]) => {
        this.cars = data;
      },
      error: (error) => {
        console.error('Error getting cars', error);
      }
    });   
  }

  deleteCar(id:number){
    this.carService.delete(id).subscribe({
      next: (data) => {
        console.log('Car deleted successfully.');

        this.getAllCars();
        this.getAllCarByIdWithPrice();
        this.dialog.open(SuccessDialogComponent, {
          data: {
            message: 'Car deleted successfully!'
          }
        });

      },
      error: (error) => {
        console.error('Error deleting car.', error);

        this.dialog.open(FailureDialogComponent, {
          data: {
            message: 'Error deleting car!'
          }
        });
      }
    })
  }

  updeteCar(id:number){

  }
}