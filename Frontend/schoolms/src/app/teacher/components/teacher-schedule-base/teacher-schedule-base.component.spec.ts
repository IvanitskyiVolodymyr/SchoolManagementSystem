import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherScheduleBaseComponent } from './teacher-schedule-base.component';

describe('TeacherScheduleBaseComponent', () => {
  let component: TeacherScheduleBaseComponent;
  let fixture: ComponentFixture<TeacherScheduleBaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherScheduleBaseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeacherScheduleBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
