import { Component, Input } from '@angular/core';
import { UrlNavigationService } from 'src/app/shared/helpers/url-navigation.service';
import { ScheduleAttendance } from 'src/app/shared/models/schedule/scheduleAttendance';
import { ResponseTask } from 'src/app/shared/models/tasks/reposponseTask';

@Component({
  selector: 'app-schedule-card',
  templateUrl: './schedule-card.component.html',
  styleUrls: ['./schedule-card.component.scss']
})
export class ScheduleCardComponent {
  @Input() scheduleAttendance: ScheduleAttendance | undefined;
  @Input() homework: ResponseTask[] = []; 

  constructor(private urlNavigationService: UrlNavigationService) { }

  public openSubjectLink(url: string | undefined) {
    this.urlNavigationService.openExternalUrl(url);
  }
}
