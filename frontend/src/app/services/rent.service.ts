import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Rent } from '../models/rent.model';

@Injectable({
  providedIn: 'root'
})
export class RentService {

  private apiUrl = 'http://localhost:5184/api/rents/';

  constructor(private http: HttpClient) { }

  addRent(rent: Rent): Observable<Rent> {
    
    return this.http.post<any>(this.apiUrl, rent);
  }

  getAllRents() {
    return this.http.get<any>(this.apiUrl);
  }


  deleteRent(id: number): Observable<any> {
    const url = `${this.apiUrl}${id}`;
    return this.http.delete<any>(url); 
  }

  getAllRentsWithFullData(customerId: number, carId: number, rentId: number, payTypeId: number, priceId: number) {

    const url = `http://localhost:5184/api/customers/viees?customerId=${customerId}&carId=${carId}&rentId=${rentId}&payTypeId=${payTypeId}&priceId=${priceId}`;
    return this.http.get<any>(this.apiUrl);
  }
}
