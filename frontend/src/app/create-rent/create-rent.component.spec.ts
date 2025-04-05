import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { CreateRentComponent } from './create-rent.component';
import { FormsModule } from '@angular/forms';

describe('CreateRentComponent', () => {
  let component: CreateRentComponent;
  let fixture: ComponentFixture<CreateRentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormsModule],
      providers: [
        provideHttpClient(withInterceptorsFromDi(), withFetch())
      ],
      declarations: [CreateRentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateRentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
