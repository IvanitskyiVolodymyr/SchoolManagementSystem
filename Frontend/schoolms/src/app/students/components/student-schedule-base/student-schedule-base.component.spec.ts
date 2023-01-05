import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentScheduleBaseComponent } from './student-schedule-base.component';

describe('StudentScheduleBaseComponent', () => {
  let component: StudentScheduleBaseComponent;
  let fixture: ComponentFixture<StudentScheduleBaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentScheduleBaseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudentScheduleBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
