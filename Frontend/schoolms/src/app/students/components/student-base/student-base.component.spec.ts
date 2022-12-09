import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentBaseComponent } from './student-base.component';

describe('StudentBaseComponent', () => {
  let component: StudentBaseComponent;
  let fixture: ComponentFixture<StudentBaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentBaseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudentBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
