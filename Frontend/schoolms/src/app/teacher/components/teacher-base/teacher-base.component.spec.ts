import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherBaseComponent } from './teacher-base.component';

describe('TeacherBaseComponent', () => {
  let component: TeacherBaseComponent;
  let fixture: ComponentFixture<TeacherBaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherBaseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeacherBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
