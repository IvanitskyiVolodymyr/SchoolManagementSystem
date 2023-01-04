import { Component } from '@angular/core';
import { NavigationModel } from 'src/app/shared/models/navigation/navigationModel';

@Component({
  selector: 'app-teacher-base',
  templateUrl: './teacher-base.component.html',
  styleUrls: ['./teacher-base.component.scss']
})
export class TeacherBaseComponent {
  public navItems: Array<NavigationModel> = [
    {
      routerLink: 'schedule',
      icon: 'timer',
      title: 'Розклад'
    },
    {
      routerLink: 'tasks',
      icon: 'work_outline',
      title: 'Завдання'
    },
    {
      routerLink: 'сlasses',
      icon: 'people',
      title: 'Класи'
    },
  ]
}
