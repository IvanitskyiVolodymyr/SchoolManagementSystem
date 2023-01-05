import { Component, Input } from '@angular/core';
import { UrlNavigationService } from 'src/app/shared/helpers/url-navigation.service';
import { ScheduleCardModel } from 'src/app/shared/models/schedule/scheduleCardModel';

@Component({
  selector: 'app-schedule-card',
  templateUrl: './schedule-card.component.html',
  styleUrls: ['./schedule-card.component.scss']
})
export class ScheduleCardComponent {
  @Input() schedule: ScheduleCardModel | undefined;

  constructor(private urlNavigationService: UrlNavigationService) { }

  public openSubjectLink(url: string | undefined) {
    this.urlNavigationService.openExternalUrl(url);
  }
}
