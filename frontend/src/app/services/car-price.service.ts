import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarPrice } from '../models/carPrice.model';

@Injectable({
  providedIn: 'root'
})
export class CarPriceService {

  constructor(private http: HttpClient) { }

  GetAllCarsWithPrice(): Observable<CarPrice[]> {
    const url = `http://localhost:5184/api/cars/price`;
    return this.http.get<CarPrice[]>(url);
  }
}
