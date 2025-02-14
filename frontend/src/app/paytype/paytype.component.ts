import { Component } from '@angular/core';
import { PaytypeService } from '../services/paytype.service';
import { PayType } from '../models/paytype.model';

@Component({
  selector: 'app-paytype',
  templateUrl: './paytype.component.html',
  styleUrl: './paytype.component.css'
})
export class PaytypeComponent {

  paystype: PayType[] = []; // Propiedad para almacenar los coches

  constructor(private paytypeService: PaytypeService) { }
  
    ngOnInit(): void {
      // Obtener los coches del servicio
      this.paytypeService.getAllPaysType().subscribe({
        next: (data: PayType[]) => {
          this.paystype = data; // Almacenar los coches obtenidos en la propiedad cars
        },
        error: (error) => {
          console.error('Error al obtener los coches', error);
        }
    });
    }

}
