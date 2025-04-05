import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { ListRentComponent } from './list-rent.component';
import { FormsModule } from '@angular/forms';

describe('ListRentComponent', () => {
  let component: ListRentComponent;
  let fixture: ComponentFixture<ListRentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormsModule],
      providers: [
        provideHttpClient(withInterceptorsFromDi(), withFetch())
      ],
      declarations: [ListRentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListRentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
