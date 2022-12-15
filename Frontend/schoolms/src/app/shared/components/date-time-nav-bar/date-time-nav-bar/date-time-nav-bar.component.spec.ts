import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DateTimeNavBarComponent } from './date-time-nav-bar.component';

describe('DateTimeNavBarComponent', () => {
  let component: DateTimeNavBarComponent;
  let fixture: ComponentFixture<DateTimeNavBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DateTimeNavBarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DateTimeNavBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
