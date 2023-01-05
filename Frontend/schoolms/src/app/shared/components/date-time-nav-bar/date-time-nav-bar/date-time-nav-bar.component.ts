import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DateRange } from 'src/app/shared/models/date/date-range';
import { DateRangeService } from 'src/app/shared/services/date-range.service';

@Component({
  selector: 'app-date-time-nav-bar',
  templateUrl: './date-time-nav-bar.component.html',
  styleUrls: ['./date-time-nav-bar.component.scss']
})
export class DateTimeNavBarComponent implements OnInit {
  @Input() title = "";
  @Input() daysDiff = 7;
  @Input() startDate: Date = new Date();
  @Input() isFromWeekBegining = false;

  @Output() dateRangeChange = new EventEmitter<DateRange>();

  constructor(private dataRangeService: DateRangeService) { }

  public dateRange: DateRange =  {startDate: new Date(), endDate: new Date()};
  private millisecondsPerDay = 24*60*60*1000;

  ngOnInit(): void {
    this.dateRange = this.getPeriodOfDate(this.startDate);
    this.dateRangeChange.emit(this.dateRange);
    this.dataRangeService.changeDateClicked(this.dateRange);
  }

  public onPreviousWeekClick() {
    const date = new Date(this.startDate.getTime() - this.daysDiff*this.millisecondsPerDay);
    this.dateRange = this.getPeriodOfDate(date);
    this.dateRangeChange.emit(this.dateRange);
    this.dataRangeService.changeDateClicked(this.dateRange);
  }

  public onNextWeekClick() {
    const date = new Date(this.startDate.getTime() + this.daysDiff*this.millisecondsPerDay);
    this.dateRange = this.getPeriodOfDate(date);
    this.dateRangeChange.emit(this.dateRange);
    this.dataRangeService.changeDateClicked(this.dateRange);
  }

  private getPeriodOfDate(date: Date) {
    const startDate = new Date(date);
    if(this.isFromWeekBegining) {
      startDate.setDate(startDate.getDate() - startDate.getDay() + 1 );
    } else {
      startDate.setDate(startDate.getDate());
    }
    startDate.setHours(0);
    startDate.setMinutes(0);
    startDate.setSeconds(0);
    this.startDate = startDate;
    this.dateRange.startDate = startDate;

    const endDate = new Date(date);
    if(this.isFromWeekBegining) {
      endDate.setDate(endDate.getDate() + this.daysDiff - endDate.getDay());
    } else {
      endDate.setDate(endDate.getDate() + this.daysDiff - 1)
    }
    endDate.setHours(23);
    endDate.setMinutes(59);
    endDate.setSeconds(59);
    this.dateRange.endDate = endDate

    return this.dateRange;
  }
}
