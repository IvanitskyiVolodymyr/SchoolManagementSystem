import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherScheduleListComponent } from './teacher-schedule-list.component';

describe('TeacherScheduleListComponent', () => {
  let component: TeacherScheduleListComponent;
  let fixture: ComponentFixture<TeacherScheduleListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherScheduleListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeacherScheduleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
