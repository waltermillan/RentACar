import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private apiUrlGetAllCustomers = 'http://localhost:5184/api/Customer/GetAll';
  private addCustomerUrl = 'http://localhost:5184/api/Customer/Add';

  constructor(private http: HttpClient) { }

  getAllCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrlGetAllCustomers);
  }

  addCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.addCustomerUrl, customer);
  }


  deleteCustomer(id: number): Observable<any> {
    const url = `http://localhost:5184/api/Customer/Delete/${id}`;  // Construir la URL con el 'id' aquí
    return this.http.delete<any>(url);  // Llamar al servicio HTTP con la URL correcta
  }
  
   
}
