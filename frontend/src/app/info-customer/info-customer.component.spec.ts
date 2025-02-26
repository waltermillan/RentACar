import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoCustomerComponent } from './info-customer.component';

describe('InfoCustomerComponent', () => {
  let component: InfoCustomerComponent;
  let fixture: ComponentFixture<InfoCustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InfoCustomerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InfoCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
