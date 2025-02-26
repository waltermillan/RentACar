import { Component, numberAttribute } from '@angular/core';
import { Car } from '../models/car.model';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrl: './car.component.css'
})
export class CarComponent {

  cars: Car[] = []; // Propiedad para almacenar los automoviles

  newCar: Car = {   // Nuevo Automovil vacío
    id: 0,
    model: '',
    brand: '',
    year: 0,
    rented: 0,
    idPrice: 0
  };

  constructor(private carService: CarService) { }

  ngOnInit(): void {

  }

  onSubmit(): void {
    const carToAdd: Car = {
      ...this.newCar
    };
  
    this.carService.addCar(carToAdd).subscribe({
      next: (data) => {
        this.cars.push(data);
        this.newCar = { id: 0, model: '', brand: '', year: 0, rented: 0, idPrice: 0 };
      },
      error: (error) => {
        console.error('Error al agregar automovil:', error);
        if (error.error && error.error.errors) {
          console.error('Detalles de los errores de validación:', error.error.errors);
        }
      }
   });
  }  

 
}