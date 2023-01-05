import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherScheduleCardComponent } from './teacher-schedule-card.component';

describe('TeacherScheduleCardComponent', () => {
  let component: TeacherScheduleCardComponent;
  let fixture: ComponentFixture<TeacherScheduleCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherScheduleCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeacherScheduleCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
