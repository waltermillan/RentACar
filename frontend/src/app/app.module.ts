import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { FormsModule } from '@angular/forms';  // Importa FormsModule

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CustomerComponent } from './customer/customer.component';
import { RentComponent } from './rent/rent.component';
import { DocumentComponent } from './document/document.component';
import { PriceComponent } from './price/price.component';

import { CarComponent } from './car/car.component';
import { PaytypeComponent } from './paytype/paytype.component';
import { InfoRentComponent } from './info-rent/info-rent.component';
import { InfoCustomerComponent } from './info-customer/info-customer.component';
import { InfoCarsComponent } from './info-cars/info-cars.component';  // Si aún no lo has importado


@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    RentComponent,
    DocumentComponent,
    PriceComponent,
    CarComponent,
    PaytypeComponent,
    InfoRentComponent,
    InfoCustomerComponent,
    InfoCarsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi(), withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
