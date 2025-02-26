import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Car } from '../models/car.model';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  private apiUrl = 'http://localhost:5184/api/cars/';

  constructor(private http: HttpClient) { }

  getAllCars(): Observable<Car[]> {
    console.log(this.apiUrl);
    return this.http.get<Car[]>(this.apiUrl);
  }

  CarUpdateRented(id: number, rentedStatus: number): Observable<Car> {
    const url = `${this.apiUrl}${id}/rented`;
    const body = { rented: rentedStatus }; 
  
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
  
    return this.http.patch<Car>(url, body, { headers });
  }


  addCar(car: Car): Observable<Car> {
      return this.http.post<Car>(this.apiUrl, car);
    }
}
