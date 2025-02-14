import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Price } from '../models/price.model';
import { PriceService } from '../services/price.service';

@Component({
  selector: 'app-price',
  templateUrl: './price.component.html',
  styleUrl: './price.component.css'
})
export class PriceComponent {

  prices: Price[] = []; // Propiedad para almacenar los coches

  constructor(private priceService: PriceService) { }

  ngOnInit(): void {
    // Obtener los coches del servicio
    this.priceService.getAllPrices().subscribe({
      next: (data: Price[]) => {
        this.prices = data; // Almacenar los coches obtenidos en la propiedad cars
      },
      error: (error) => {
        console.error('Error al obtener los coches', error);
      }
  });
  }

}
