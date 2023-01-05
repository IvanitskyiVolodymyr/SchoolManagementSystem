import { EventEmitter, Injectable, Output } from '@angular/core';
import { DateRange } from '../models/date/date-range';

@Injectable({
  providedIn: 'root'
})
export class DateRangeService {

  constructor() { }

  @Output() dateRangeEvent = new EventEmitter<DateRange>();

    changeDateClicked(dateRange: DateRange) {
      this.dateRangeEvent.emit(dateRange);
  }
}
