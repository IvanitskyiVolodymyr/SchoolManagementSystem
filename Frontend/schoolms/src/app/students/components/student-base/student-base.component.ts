import { Component } from '@angular/core';
import { NavigationModel } from 'src/app/shared/models/navigation/navigationModel';

@Component({
  selector: 'app-student-base',
  templateUrl: './student-base.component.html',
  styleUrls: ['./student-base.component.scss']
})
export class StudentBaseComponent {
  public navItems: Array<NavigationModel> = [
    {
      routerLink: 'schedule',
      icon: 'timer',
      title: 'Щоденник'
    },
    {
      routerLink: 'tasks',
      icon: 'work_outline',
      title: 'Завдання'
    },
    {
      routerLink: 'journal',
      icon: 'table_chart',
      title: 'Журнал'
    },
    /*{
      routerLink: 'attendance',
      icon: 'sentiment_satisfied_alt',
      title: 'Відвідуваність'
    },*/
  ]
}
