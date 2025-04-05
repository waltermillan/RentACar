import { Component, numberAttribute } from '@angular/core';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';
import { MatDialog } from '@angular/material/dialog';
import { SuccessDialogComponent } from '../modals/success-dialog/success-dialog.component';
import { FailureDialogComponent } from '../modals/failure-dialog/failure-dialog.component';

@Component({
  selector: 'app-list-customer',
  templateUrl: './list-customer.component.html',
  styleUrl: './list-customer.component.css'
})
export class ListCustomerComponent {

    customers: Customer[] = [];
  
    newCustomer: Customer = {
      id: 0,
      name: '',
      document: '',
      documentType: 0,
      birthDate: new Date()
    };

    constructor(private customerService: CustomerService,
                private dialog: MatDialog) {

    }

    ngOnInit(): void{
      this.getAllCustomers();
    }

    getAllCustomers(){
      this.customerService.getAll().subscribe({
        next: (data: Customer[]) => {
          this.customers = data; 
        },
        error: (error) => {
          console.error('Error getting custoners', error);
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
          return 'Unknown';
      }
    }
  
    deleteCustomer(id: number): void {
      this.customerService.delete(id).subscribe({
        next: (data) => {
          console.log('Task deleted successfully. ', data);

          this.dialog.open(SuccessDialogComponent, {
            data: {
              message: 'Customer deleted successfully!'
            }
          });

          this.customerService.getAll().subscribe({
            next: (updatedCustomers) => {
              this.customers = updatedCustomers;
            },
            error: (error) => {
              console.error('Error getting updated customers: ', error);
            }
          });
        },
        error: (error) => {
          console.error('Error deleting tasks: ', error);

          this.dialog.open(FailureDialogComponent, {
            data: {
              message: 'Error deleting tasks'
            }
          });
        }
      });
    }

    updeteCar(id:number){
      
    }
}
