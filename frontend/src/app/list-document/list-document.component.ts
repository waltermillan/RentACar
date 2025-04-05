import { Component } from '@angular/core';
import { Document } from '../models/document.model';
import { DocumentService } from '../services/document.service';

@Component({
  selector: 'app-list-document',
  templateUrl: './list-document.component.html',
  styleUrl: './list-document.component.css'
})
export class ListDocumentComponent {

  documents: Document[] = [];

  constructor(private priceService: DocumentService) { }

  ngOnInit(): void {
    this.priceService.getAll().subscribe({
      next: (data: Document[]) => {
        this.documents = data; 
      },
      error: (error) => {
        console.error('Error getting cars.', error);
      }
  });
  }

}
