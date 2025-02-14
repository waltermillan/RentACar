import { Component } from '@angular/core';
import { Car } from '../models/car.model';
import { CarService } from '../services/car.service';
import { CarPriceService } from '../services/car-price.service';
import { CarPrice } from '../models/carPrice.model';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrl: './car.component.css'
})
export class CarComponent {

  cars: Car[] = []; // Propiedad para almacenar los coches
  carprice:CarPrice[] = [];

  constructor(private carService: CarService, 
              private carPriceService: CarPriceService
  ) { }

  ngOnInit(): void {
    this.getAllCars();
    this.getAllCarByIdWithPrice();
  }

  getAllCarByIdWithPrice():any{
    this.carPriceService.GetAllCarsWithPrice().subscribe({
      next: (data: CarPrice[]) => {
        this.carprice = data; // Almacenar los coches obtenidos en la propiedad cars
      },
      error: (error) => {
        console.error('Error al obtener los autos con precios', error);
      }
    }); 
  }

  getAllCars(){
     // Obtener los coches del servicio
    this.carService.getAllCars().subscribe({
      next: (data: Car[]) => {
        this.cars = data; // Almacenar los coches obtenidos en la propiedad cars
      },
      error: (error) => {
        console.error('Error al obtener los coches', error);
      }
  });   
  }
}