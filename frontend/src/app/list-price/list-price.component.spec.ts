import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { ListPriceComponent } from './list-price.component';
import { FormsModule } from '@angular/forms';

describe('ListPriceComponent', () => {
  let component: ListPriceComponent;
  let fixture: ComponentFixture<ListPriceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormsModule],
      providers: [
        provideHttpClient(withInterceptorsFromDi(), withFetch())
      ],
      declarations: [ListPriceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListPriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
