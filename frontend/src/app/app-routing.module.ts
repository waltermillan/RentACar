import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CreateCarComponent } from './create-car/create-car.component';
import { CreateCustomerComponent } from './create-customer/create-customer.component';
import { CreateRentComponent } from './create-rent/create-rent.component';
import { ListDocumentComponent } from './list-document/list-document.component';
import { ListPriceComponent } from './list-price/list-price.component';
import { ListPaytypeComponent } from './list-paytype/list-paytype.component';
import { ListRentComponent } from './list-rent/list-rent.component';
import { ListCustomerComponent } from './list-customer/list-customer.component';
import { ListCarsComponent } from './list-cars/list-cars.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { ListUsersComponent } from './list-users/list-users.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'create-customers', component: CreateCustomerComponent },
  { path: 'create-rents', component: CreateRentComponent },
  { path: 'create-cars', component: CreateCarComponent },  

  { path: 'list-rents', component: ListRentComponent },  
  { path: 'list-documents', component: ListDocumentComponent },
  { path: 'list-prices', component: ListPriceComponent },
  { path: 'list-paytype', component: ListPaytypeComponent },
  { path: 'list-customers', component: ListCustomerComponent },
  { path: 'list-cars', component: ListCarsComponent },
  { path: 'list-users', component: ListUsersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
