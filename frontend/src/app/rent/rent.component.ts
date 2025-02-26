import { Component, numberAttribute } from '@angular/core';
import { DatePipe } from '@angular/common';

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
  selector: 'app-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.css'],
  providers: [DatePipe]
})
export class RentComponent {
  // Opciones para los combos
  customers: Customer[] = []; // Propiedad para almacenar los clientes
  carsPrice: CarPrice [] = []; // Propiedad para almacenar los automoviles

  //tiposPago = ['Tarjeta de Crédito', 'Tarjeta de Débito', 'Efectivo'];
  paysType: PayType[] = []; // Propiedad para almacenar los tipos de pagos
  //precios = ['100$', '200$', '300$'];

  rentDays: number = 0;  // Iniciar en 0 días de alquiler

  rent: Rent = {} as Rent;

  // Variables de binding
  selectedCliente: string = '';
  selectedAutomovil: string = '';
  selectedPago: string = '';
  selectedPrecio: string = '';
  selectedPriceId:string = '';

  constructor(private customerService:CustomerService, 
              private carPriceService:CarPriceService,
              private paytypeService:PaytypeService,
              private rentService: RentService,
              private carService:CarService,
              private datePipe: DatePipe) {
        
  }

  ngOnInit(){
    this.getAllCustomers();
    this.getAllCarsWithPrice();
    this.getAllTypesPay();
  }

  // Función que se ejecuta al hacer clic en "Alquilar"
  rentCar(): void {
    // alert(`id_customer: ${this.selectedCliente}\n
    //        id_car: ${this.selectedAutomovil}\n
    //        day: ${this.getFormattedDate()}\n
    //        pay_type_id: ${this.selectedPago}\n
    //        price_id: ${this.selectedPriceId}\n,
    //        days: ${this.rentDays}`);

    this.rent.idCustomer = parseInt(this.selectedCliente);
    this.rent.idCar = parseInt(this.selectedAutomovil);
    //this.rent.day = this.getFormattedDate().toString();
    this.rent.payTypeId = parseInt(this.selectedPago);
    this.rent.priceId = parseInt(this.selectedPriceId)

    this.rent.day = this.datePipe.transform(new Date(), 'yyyy-MM-dd')!;
    this.rent.dayRemaining = this.datePipe.transform(this.getReturnDay(this.rentDays), 'yyyy-MM-dd')!;


    // Asegúrate de que la respuesta sea manejada correctamente
    this.rentService.addRent(this.rent).subscribe({
    next: (response) => {
      console.log('Alquiler realizado con éxito', response);
      this.carUpdateRented(this.rent.idCar); // Cambio el estado del automovil
    },
    error: (error) => {
      console.error('Error al realizar el alquiler', error);
    }
  });

    //this.rentService.addRent(this.rent);
  }

  getReturnDay(rentDays: number): Date {
    const currentDate = new Date(); // Obtén la fecha actual
    
    // Sumar los días a la fecha actual
    currentDate.setDate(currentDate.getDate() + rentDays);
  
    // Retorna el objeto Date con los días sumados
    return currentDate;
  }
  

  getFormattedDate() : Date {
    const currentDate = new Date();
    return currentDate;
  }

  getAllCustomers(){
        this.customerService.getAllCustomers().subscribe({
          next: (data: Customer[]) => {
            this.customers = data; // Almacenar los clientes obtenidos en la propiedad customers
          },
          error: (error) => {
            console.error('Error al obtener los clientes', error);
          }
  });
  }

  getAllCarsWithPrice(){
    this.carPriceService.GetAllCarsWithPrice().subscribe({
      next: (data: CarPrice[]) => 
      {
        this.carsPrice = data.filter(c => !c.car.rented); // Almacenar los automoviles obtenidos en la propiedad cars que esten libres.
      },
      error: (error) => 
      {
        console.error('Error al obtener los automoviles', error);
      }
  });
}

  getAllTypesPay(){
    this.paytypeService.getAllPaysType().subscribe({
      next: (data: PayType[]) =>
      {
        this.paysType = data;
      },
      error: (error) =>
      {
        console.error('Error al obtener los tipos de pagos', error);
      }
    });
  }

  carUpdateRented(id:number){
    this.carService.CarUpdateRented(id, 1).subscribe({
      next: (data) => {
        console.log('Estado de automovil actualizado con éxito:', data);
      },
      error: (error) => {
        console.error('Error al actualizar el estado del coche:', error);
      }
    })
  }

  // Incrementa un día
  addDay() {
    this.rentDays++;
  }

  // Decrementa un día, asegurándonos de que no sea negativo
  subDay() {
    if (this.rentDays > 0) {
      this.rentDays--;
    }
  }

  onCarChange() {
    const selectedCar = this.carsPrice.find(cp => cp.car.id.toString() === this.selectedAutomovil);
    if (selectedCar) {
      this.selectedPriceId = selectedCar.price.id.toString();
    }
  }
}
