import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common'

@Pipe({
  name: 'ukrainianDate'
})

export class CustomUkrainianDatePipe implements PipeTransform {

  private dayOfWeek: Map<string, string> = new Map<string, string>();
  private months: Map<string, string> = new Map<string, string>();

  constructor(public datepipe: DatePipe) {
    this.initDays();
    this.initMonths();
  }
  transform(date: string | null): string {

    let transformed_date = date as string;

    Array.from(this.dayOfWeek.keys()).forEach(element => {
      transformed_date = transformed_date?.replace(element, this.dayOfWeek.get(element) as string);
    });

    Array.from(this.months.keys()).forEach(element => {
      transformed_date = transformed_date?.replace(element, this.months.get(element) as string);
    });
    
    return transformed_date as string;
  }

  private initDays() {
    this.dayOfWeek.set("Monday", "Понеділок"); 
    this.dayOfWeek.set("Tuesday", "Вівторок");
    this.dayOfWeek.set("Wednesday", "Середа");
    this.dayOfWeek.set("Thursday", "Четвер");
    this.dayOfWeek.set("Friday", "П'ятниця");
    this.dayOfWeek.set("Saturday", "Субота");
    this.dayOfWeek.set("Sunday", "Неділя");
  }

  private initMonths() {
    this.months.set('January','Січня');
    this.months.set('February', 'Лютого');
    this.months.set('March','Березня');
    this.months.set('April','Квітня');
    this.months.set('May','Травня');
    this.months.set('June','Червня');
    this.months.set('July','Липня');
    this.months.set('August','Серпня');
    this.months.set('September','Вересня');
    this.months.set('October','Жовтня');
    this.months.set('November','Листопада');
    this.months.set('December','Грудня');
  }
}
