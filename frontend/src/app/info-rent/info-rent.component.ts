import { Component, OnInit } from '@angular/core';
import { Rent } from '../models/rent.model';
import { CustomerDTO } from '../models/customerDTO.model';
import { RentService } from '../services/rent.service';
import { CustomerService } from '../services/customer.service';
import { CarService } from '../services/car.service';


@Component({
  selector: 'app-info-rent',
  templateUrl: './info-rent.component.html',
  styleUrl: './info-rent.component.css'
})
export class InfoRentComponent implements OnInit{

  rents:Rent[] = []

  constructor(private rentService: RentService,
              private carService: CarService,
              private customerService: CustomerService
  ) {

  }

  ngOnInit(): void {
    this.getAllRents();
    
  }

  deleteRent(id: number, idCar:number){
    this.rentService.deleteRent(id).subscribe({
      next: (data) => {
        console.log('Baja alquiler realizada!');
        this.carUpdateRented(idCar, 0);
        this.getAllRents();
      },
      error: (error) => {
        console.error('Error al eliminar cliente:', error);
        if (error.error && error.error.errors) {
          console.error('Detalles de los errores de validación:', error.error.errors);
        }
      }
    })
  }

  carUpdateRented(id:number, rented:number){
    this.carService.CarUpdateRented(id, rented).subscribe({
      next: (data) => {
        console.log('Estado de automovol actualizado con éxito:', data);
      },
      error: (error) => {
        console.error('Error al actualizar el estado del coche:', error);
      }
    })
  }

  getAllRents(): any{
    this.rentService.getAllRents().subscribe({
      next: (data:Rent[]) => {
        this.rents = data;
      },
      error: (error) => {
        console.error('Error al listar clientes:', error);
        if (error.error && error.error.errors) {
          console.error('Detalles de los errores de validación:', error.error.errors);
        }
      }
    });
  }

  customerDTO?: CustomerDTO; 

  getAllRentsWithFullData(rent:Rent): any{
    this.rentService.getAllRentsWithFullData(rent.idCustomer, rent.idCar, rent.id, rent.payTypeId, rent.priceId).subscribe({
      next: (data:Rent[]) => {
        this.rents = data;
      },
      error: (error) => {
        console.error('Error al listar clientes:', error);
        if (error.error && error.error.errors) {
          console.error('Detalles de los errores de validación:', error.error.errors);
        }
      }
    });
  }
  
}
