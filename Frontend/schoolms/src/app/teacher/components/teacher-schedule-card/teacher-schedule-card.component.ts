import { Component, Input } from '@angular/core';
import { UrlNavigationService } from 'src/app/shared/helpers/url-navigation.service';
import { ScheduleWithClassSubject } from 'src/app/shared/models/schedule/scheduleWithClassSubject';

@Component({
  selector: 'app-teacher-schedule-card',
  templateUrl: './teacher-schedule-card.component.html',
  styleUrls: ['./teacher-schedule-card.component.scss']
})
export class TeacherScheduleCardComponent {

  @Input() schedule: ScheduleWithClassSubject | undefined;
  @Input() planning!: string; 

  constructor(private urlNavigationService: UrlNavigationService) { }

  public openSubjectLink(url: string | undefined) {
    this.urlNavigationService.openExternalUrl(url);
  }
}
