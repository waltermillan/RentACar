import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PayType } from '../models/paytype.model';

@Injectable({
  providedIn: 'root'
})
export class PaytypeService {

  constructor(private http: HttpClient) { }

    private apiUrl = 'http://localhost:5184/api/PayType/GetAll';
  
    getAllPaysType(): Observable<PayType[]> {
      return this.http.get<PayType[]>(this.apiUrl);
    }
}
