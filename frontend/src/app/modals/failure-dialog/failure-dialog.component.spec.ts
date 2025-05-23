import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FailureDialogComponent } from './failure-dialog.component';

describe('FailureDialogComponent', () => {
  let component: FailureDialogComponent;
  let fixture: ComponentFixture<FailureDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FailureDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FailureDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
