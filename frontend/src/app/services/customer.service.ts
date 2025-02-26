import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private apiUrl = 'http://localhost:5184/api/customers/';

  constructor(private http: HttpClient) { }

  getAllCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl);
  }

  addCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.apiUrl, customer);
  }


  deleteCustomer(id: number): Observable<any> {
    const url = `${this.apiUrl}{id}`;  // Construir la URL con el 'id' aquí
    return this.http.delete<any>(url);  // Llamar al servicio HTTP con la URL correcta
  }
  
   
}
