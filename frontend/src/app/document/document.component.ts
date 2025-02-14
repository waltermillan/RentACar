import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Document } from '../models/document.model';
import { DocumentService } from '../services/document.service';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrl: './document.component.css'
})
export class DocumentComponent {

  documents: Document[] = []; // Propiedad para almacenar los coches

  constructor(private priceService: DocumentService) { }

  ngOnInit(): void {
    // Obtener los coches del servicio
    this.priceService.getAllDocuments().subscribe({
      next: (data: Document[]) => {
        this.documents = data; // Almacenar los coches obtenidos en la propiedad cars
      },
      error: (error) => {
        console.error('Error al obtener los coches', error);
      }
  });
  }

}
