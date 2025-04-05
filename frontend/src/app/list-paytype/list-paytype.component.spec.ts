import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { ListPaytypeComponent } from './list-paytype.component';
import { FormsModule } from '@angular/forms';

describe('ListPaytypeComponent', () => {
  let component: ListPaytypeComponent;
  let fixture: ComponentFixture<ListPaytypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormsModule],
      providers: [
        provideHttpClient(withInterceptorsFromDi(), withFetch())
      ],
      declarations: [ListPaytypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListPaytypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
