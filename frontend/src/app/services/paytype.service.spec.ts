import { TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { PaytypeService } from './paytype.service';

describe('PaytypeService', () => {
  let service: PaytypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(withInterceptorsFromDi(), withFetch())
      ],
    });
    service = TestBed.inject(PaytypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
