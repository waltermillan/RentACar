import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Price } from '../models/price.model';
import { PriceService } from '../services/price.service';

@Component({
  selector: 'app-list-price',
  templateUrl: './list-price.component.html',
  styleUrl: './list-price.component.css'
})
export class ListPriceComponent {

  prices: Price[] = [];

  constructor(private priceService: PriceService) { }

  ngOnInit(): void {

    this.priceService.getAll().subscribe({
      next: (data: Price[]) => {
        this.prices = data; 
      },
      error: (error) => {
        console.error('Error getting cars.', error);
      }
  });
  }

}
