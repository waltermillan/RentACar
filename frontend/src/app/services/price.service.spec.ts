import { TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { PriceService } from './price.service';

describe('PriceService', () => {
  let service: PriceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(withInterceptorsFromDi(), withFetch())
      ],
    });
    service = TestBed.inject(PriceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
