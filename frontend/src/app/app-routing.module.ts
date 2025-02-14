import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CarComponent } from './car/car.component';
import { CustomerComponent } from './customer/customer.component';
import { RentComponent } from './rent/rent.component';
import { DocumentComponent } from './document/document.component';
import { PriceComponent } from './price/price.component';
import { PaytypeComponent } from './paytype/paytype.component';

const routes: Routes = [
  { path: 'clientes', component: CustomerComponent },
  { path: 'alquileres', component: RentComponent },
  { path: 'documentos', component: DocumentComponent },
  { path: 'precios', component: PriceComponent },
  { path: 'automoviles', component: CarComponent },
  { path: 'TipoPago', component: PaytypeComponent }
  //{ path: '', redirectTo: '/automoviles', pathMatch: 'full' }  // Ruta predeterminada
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
