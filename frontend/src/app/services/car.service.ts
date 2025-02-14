import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Car } from '../models/car.model';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  private apiUrl = 'http://localhost:5184/api/Car/GetAll';

  constructor(private http: HttpClient) { }

  getAllCars(): Observable<Car[]> {
    return this.http.get<Car[]>(this.apiUrl);
  }
   
}
