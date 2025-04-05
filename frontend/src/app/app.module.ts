import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; 
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CreateCustomerComponent } from './create-customer/create-customer.component';
import { CreateRentComponent } from './create-rent/create-rent.component';
import { ListDocumentComponent } from './list-document/list-document.component';
import { ListPriceComponent } from './list-price/list-price.component';

import { CreateCarComponent } from './create-car/create-car.component';
import { ListPaytypeComponent } from './list-paytype/list-paytype.component';
import { ListRentComponent } from './list-rent/list-rent.component';
import { ListCustomerComponent } from './list-customer/list-customer.component';
import { ListCarsComponent } from './list-cars/list-cars.component';
import { LoginComponent } from './login/login.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HomeComponent } from './home/home.component';
import { SuccessDialogComponent } from './modals/success-dialog/success-dialog.component';
import { FailureDialogComponent } from './modals/failure-dialog/failure-dialog.component';
import { ListUsersComponent } from './list-users/list-users.component'; 

@NgModule({
  declarations: [
    AppComponent,
    CreateCustomerComponent,
    CreateRentComponent,
    ListDocumentComponent,
    ListPriceComponent,
    CreateCarComponent,
    ListPaytypeComponent,
    ListRentComponent,
    ListCustomerComponent,
    ListCarsComponent,
    LoginComponent,
    HomeComponent,
    SuccessDialogComponent,
    FailureDialogComponent,
    ListUsersComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatSnackBarModule,
    MatDialogModule
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi(), withFetch()),
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
