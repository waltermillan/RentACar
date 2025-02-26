import { Component, numberAttribute } from '@angular/core';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-info-customer',
  templateUrl: './info-customer.component.html',
  styleUrl: './info-customer.component.css'
})
export class InfoCustomerComponent {

    customers: Customer[] = []; // Propiedad para almacenar los coches
  
    newCustomer: Customer = {   // Nuevo cliente vacío
      id: 0,
      name: '',
      document: '',
      documentType: 0,
      birthDate: new Date()
    };

    constructor(private customerService: CustomerService) {

    }

    ngOnInit(): void{
      // Obtener los clientes del servicio
      this.getAllCustomers();
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

    getDocumentTypeName(type: number): string {
    
      switch (type){
        case 1:
          return 'DNI';
          break;
        case 2:
          return 'NIE';
          break;
        case 3:
          return 'TIE';
          break;
        case 4:
          return 'DNIe';
          break;
        case 5:
          return 'DNI 3.0';
          break;
        default:
          return 'Desconocido';  // En caso de que el tipo no sea uno de los esperados
      }
    }
  
    deleteCustomer(id: number): void {
      this.customerService.deleteCustomer(id).subscribe({
        next: (data) => {
          console.log('Tarea eliminada con éxito', data);
          this.customerService.getAllCustomers().subscribe({
            next: (updatedCustomers) => {
              // Aquí actualizas la lista de clientes con los clientes más recientes
              this.customers = updatedCustomers;
            },
            error: (error) => {
              console.error('Error al obtener los clientes actualizados:', error);
            }
          });
        },
        error: (error) => {
          console.error('Error al eliminar tarea:', error);
        }
      });
    }
}
