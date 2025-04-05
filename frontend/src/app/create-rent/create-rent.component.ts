import { Component, numberAttribute } from '@angular/core';
import { DatePipe } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { SuccessDialogComponent } from '../modals/success-dialog/success-dialog.component';
import { FailureDialogComponent } from '../modals/failure-dialog/failure-dialog.component';

import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

import { CarPriceService } from '../services/car-price.service';

import { PayType } from '../models/paytype.model';
import { PaytypeService } from '../services/paytype.service';
import { CarPrice } from '../models/carPrice.model';

import { Rent } from '../models/rent.model';
import { RentService } from '../services/rent.service';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-create-rent',
  templateUrl: './create-rent.component.html',
  styleUrls: ['./create-rent.component.css'],
  providers: [DatePipe]
})
export class CreateRentComponent {
  customers: Customer[] = []; 
  carsPrice: CarPrice [] = []; 

  paysType: PayType[] = []; 

  rentDays: number = 1; 

  rent: Rent = {} as Rent;

  selectedCliente: string = '';
  selectedCar: string = '';
  selectedPago: string = '';
  selectedPrecio: string = '';
  selectedPriceId:string = '';

  constructor(private customerService:CustomerService, 
              private carPriceService:CarPriceService,
              private paytypeService:PaytypeService,
              private rentService: RentService,
              private carService:CarService,
              private datePipe: DatePipe,
              private dialog: MatDialog) {   
  }

  ngOnInit(){
    this.getAllCustomers();
    this.getAllCarsWithPrice();
    this.getAllTypesPay();
  }

  rentCar(): void {
    this.rent.idCustomer = parseInt(this.selectedCliente);
    this.rent.idCar = parseInt(this.selectedCar);

    this.rent.payTypeId = parseInt(this.selectedPago);
    this.rent.priceId = parseInt(this.selectedPriceId)

    this.rent.day = this.datePipe.transform(new Date(), 'yyyy-MM-dd')!;
    this.rent.dayRemaining = this.datePipe.transform(this.getReturnDay(this.rentDays), 'yyyy-MM-dd')!;

    this.rentService.addRent(this.rent).subscribe({
    next: (response) => {
      this.carUpdateRented(this.rent.idCar);

      console.log('Rent added successfully.', response);
      this.dialog.open(SuccessDialogComponent, {
        data: {
          message: 'Rent added successfully!'
        }
      });
    },
    error: (error) => {
      console.error('Error adding rent', error);
      this.dialog.open(FailureDialogComponent, {
        data: {
          message: 'Error adding rent!'
        }
      });
    }
  });
  }

  getReturnDay(rentDays: number): Date {
    const currentDate = new Date();
    currentDate.setDate(currentDate.getDate() + rentDays);
    return currentDate;
  }
  
  getFormattedDate() : Date {
    const currentDate = new Date();
    return currentDate;
  }

  getAllCustomers(){
        this.customerService.getAll().subscribe({
          next: (data: Customer[]) => {
            this.customers = data;
          },
          error: (error) => {
            console.error('Error getting customers.', error);
          }
  });
  }

  getAllCarsWithPrice(){
    this.carPriceService.GetAllCarsWithPrice().subscribe({
      next: (data: CarPrice[]) => 
      {
        this.carsPrice = data.filter(c => !c.car.rented);
      },
      error: (error) => 
      {
        console.error('Error getting cars.', error);
      }
  });
}

  getAllTypesPay(){
    this.paytypeService.getAll().subscribe({
      next: (data: PayType[]) =>
      {
        this.paysType = data;
      },
      error: (error) =>
      {
        console.error('Error getting paytypes.', error);
      }
    });
  }

  carUpdateRented(id:number){
    this.carService.updateRented(id, 1).subscribe({
      next: (data) => {
        console.log('Car\'s state updating successfully: ', data);
      },
      error: (error) => {
        console.error('Error updating car\'s state :', error);
      }
    })
  }

  addDay() {
    this.rentDays++;
  }

  subDay() {

    if (this.rentDays > 1)
      this.rentDays--;

    if (this.rentDays == 1){
      this.dialog.open(FailureDialogComponent, {
        data: {
          message: 'the rental day can\'t be less than 1'
        }
      });
    }

  }

  onCarChange() {
    const selectedCar = this.carsPrice.find(cp => cp.car.id.toString() === this.selectedCar);
    if (selectedCar) {
      this.selectedPriceId = selectedCar.price.id.toString();
    }
  }
}
