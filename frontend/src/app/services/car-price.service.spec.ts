import { TestBed } from '@angular/core/testing';

import { CarPriceService } from './car-price.service';

describe('CarPriceService', () => {
  let service: CarPriceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarPriceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
