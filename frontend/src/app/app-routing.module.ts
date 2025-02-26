import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CarComponent } from './car/car.component';
import { CustomerComponent } from './customer/customer.component';
import { RentComponent } from './rent/rent.component';
import { DocumentComponent } from './document/document.component';
import { PriceComponent } from './price/price.component';
import { PaytypeComponent } from './paytype/paytype.component';
import { InfoRentComponent } from './info-rent/info-rent.component';
import { InfoCustomerComponent } from './info-customer/info-customer.component';
import { InfoCarsComponent } from './info-cars/info-cars.component';

const routes: Routes = [
  { path: 'clientes', component: CustomerComponent },
  { path: 'alquileres', component: RentComponent },
  { path: 'documentos', component: DocumentComponent },
  { path: 'precios', component: PriceComponent },
  { path: 'automoviles', component: CarComponent },
  { path: 'TipoPago', component: PaytypeComponent },
  { path: 'info-alquiler', component: InfoRentComponent },
  { path: 'info-clientes', component: InfoCustomerComponent },
  { path: 'info-automoviles', component: InfoCarsComponent }

  //{ path: '', redirectTo: '/automoviles', pathMatch: 'full' }  // Ruta predeterminada
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
