import { Component } from '@angular/core';
import { GLOBAL_CONFIG } from '../config/config.global';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  title:string = GLOBAL_CONFIG.appFullName;;
  constructor() {

  }

}
