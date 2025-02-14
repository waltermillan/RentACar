import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Rent } from '../models/rent.model';

@Injectable({
  providedIn: 'root'
})
export class RentService {

  private urlAddRent = 'http://localhost:5184/api/Rent/Add';

  constructor(private http: HttpClient) { }

  addRent(rent: Rent): Observable<Rent> {
    console.log('url: ' + this.urlAddRent);
    console.log('rent: ' + JSON.stringify(rent, null, 2));

    return this.http.post<Rent>(this.urlAddRent, rent);
  }
}
