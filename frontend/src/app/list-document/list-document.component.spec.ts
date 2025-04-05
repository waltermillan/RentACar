import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { ListDocumentComponent } from './list-document.component';
import { FormsModule } from '@angular/forms';

describe('ListDocumentComponent', () => {
  let component: ListDocumentComponent;
  let fixture: ComponentFixture<ListDocumentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormsModule],
      providers: [
        provideHttpClient(withInterceptorsFromDi(), withFetch())
      ],
      declarations: [ListDocumentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListDocumentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
