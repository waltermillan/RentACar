import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoCarsComponent } from './info-cars.component';

describe('InfoCarsComponent', () => {
  let component: InfoCarsComponent;
  let fixture: ComponentFixture<InfoCarsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InfoCarsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InfoCarsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
