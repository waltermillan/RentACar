import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PayType } from '../models/paytype.model';
import { Price } from '../models/price.model';


@Injectable({
  providedIn: 'root'
})
export class PriceService {

  constructor(private http: HttpClient) { }

    prices:Price [] = [];
  
    private apiUrl = 'http://localhost:5184/api/prices/';
  
  
    getAllPrices(): Observable<Price[]> {
      return this.http.get<Price[]>(this.apiUrl);
    }

  
}
