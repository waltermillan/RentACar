import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Document } from '../models/document.model';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {

  constructor(private http: HttpClient) { }
  
    private apiUrl = 'http://localhost:5184/api/Document/GetAll';
  
  
    getAllDocuments(): Observable<Document[]> {
      return this.http.get<Document[]>(this.apiUrl);
    }
}
