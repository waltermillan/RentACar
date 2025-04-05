import { TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { CarPriceService } from './car-price.service';

describe('CarPriceService', () => {
  let service: CarPriceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(withInterceptorsFromDi(), withFetch())
      ],
    });
    service = TestBed.inject(CarPriceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
