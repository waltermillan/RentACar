import { Component } from '@angular/core';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';
import { MatDialog } from '@angular/material/dialog';
import { SuccessDialogComponent } from '../modals/success-dialog/success-dialog.component';

@Component({
  selector: 'app-create-customer',
  templateUrl: './create-customer.component.html',
  styleUrl: './create-customer.component.css'
})
export class CreateCustomerComponent {

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

  ngOnInit(): void {
  }

  onSubmit(): void {
    const customerToAdd: Customer = {
      ...this.newCustomer
    };
  
    this.customerService.add(customerToAdd).subscribe({
      next: (addedCustomer) => {
        this.customers.push(addedCustomer);
        this.newCustomer = { id: 0, name: '', document: '', documentType: 0, birthDate: new Date() };

        this.dialog.open(SuccessDialogComponent, {
          data: {
            message: 'Customer added successfully!'
          }
        });
      },
      error: (error) => {
        console.error('Error adding customer:', error);
        if (error.error && error.error.errors) {
          console.error('Error\'s details from validation:', error.error.errors);
        }
      }
   });
  }  
}