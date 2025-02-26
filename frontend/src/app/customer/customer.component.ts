import { Component, numberAttribute } from '@angular/core';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent {

  customers: Customer[] = []; // Propiedad para almacenar los coches

  newCustomer: Customer = {   // Nuevo cliente vacío
    id: 0,
    name: '',
    document: '',
    documentType: 0,
    birthDate: new Date()
  };

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    // Obtener los clientes del servicio
    //this.getAllCustomers();
  }

  onSubmit(): void {
    const customerToAdd: Customer = {
      ...this.newCustomer
    };
  
    this.customerService.addCustomer(customerToAdd).subscribe({
      next: (addedCustomer) => {
        this.customers.push(addedCustomer);
        this.newCustomer = { id: 0, name: '', document: '', documentType: 0, birthDate: new Date() };
      },
      error: (error) => {
        console.error('Error al agregar cliente:', error);
        if (error.error && error.error.errors) {
          console.error('Detalles de los errores de validación:', error.error.errors);
        }
      }
   });
  }  

 
}