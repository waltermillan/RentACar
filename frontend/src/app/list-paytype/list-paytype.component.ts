import { Component } from '@angular/core';
import { PaytypeService } from '../services/paytype.service';
import { PayType } from '../models/paytype.model';

@Component({
  selector: 'app-list-paytype',
  templateUrl: './list-paytype.component.html',
  styleUrl: './list-paytype.component.css'
})
export class ListPaytypeComponent {

  paystype: PayType[] = [];

  constructor(private paytypeService: PaytypeService) { }
  
    ngOnInit(): void {
      this.paytypeService.getAll().subscribe({
        next: (data: PayType[]) => {
          this.paystype = data; 
        },
        error: (error) => {
          console.error('Error getting cars.', error);
        }
    });
    }

}
