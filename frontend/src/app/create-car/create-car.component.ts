import { Component, numberAttribute } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SuccessDialogComponent } from '../modals/success-dialog/success-dialog.component';


import { Car } from '../models/car.model';
import { CarService } from '../services/car.service';
import { PriceService } from '../services/price.service';
import { Price } from '../models/price.model';

@Component({
  selector: 'app-create-car',
  templateUrl: './create-car.component.html',
  styleUrl: './create-car.component.css'
})
export class CreateCarComponent {

  cars: Car[] = []; 

  newCar: Car = { 
    id: 0,
    model: '',
    brand: '',
    year: 0,
    rented: 0,
    idPrice: 0
  };

  years: number [] = [];
  prices: Price [] = [];

  constructor(private carService: CarService,
              private priceService: PriceService,
              private dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadYears();
    this.loadPrices();
  }

  loadYears(){
    const currentYear = new Date().getFullYear();
    const endYear = currentYear - 50;

    for (let i = currentYear; i >= endYear; i--) {
      this.years.push(i);
    }
  }

  loadPrices(){
    this.priceService.getAll().subscribe({
      next: (data) => {
        this.prices = data;
        console.log('Prices added successfully.');
      },
      error: (error) => {
        console.error('Error adding prices.', error);
      }
    });
  }

  onSubmit(): void {
    const carToAdd: Car = {
      ...this.newCar
    };
  
    this.carService.add(carToAdd).subscribe({
      next: (data) => {
        this.cars.push(data);
        this.newCar = { id: 0, model: '', brand: '', year: 0, rented: 0, idPrice: 0 };
        this.dialog.open(SuccessDialogComponent, {
          data: {
            message: 'Car added successfully!'
          }
        });
      },
      error: (error) => {
        console.error('Error adding car:', error);
        if (error.error && error.error.errors) {
          console.error('Details from validation\'s errors:', error.error.errors);
        }
      }
   });
  }   
}