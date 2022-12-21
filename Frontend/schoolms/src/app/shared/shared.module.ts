import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { EffectsModule } from '@ngrx/effects';
import { UserEffects } from '../store/effects/user.effects';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ScheduleCardComponent } from './components/schedule/schedule-card/schedule-card.component';
import { ScheduleListComponent } from './components/schedule/schedule-list/schedule-list.component';
import { CustomUkrainianDatePipe } from './pipes/custom-ukrainian-date.pipe';
import { MatRadioModule } from '@angular/material/radio';
import { TaskTypePipe } from './pipes/task-type.pipe';
import { DateTimeNavBarComponent } from './components/date-time-nav-bar/date-time-nav-bar/date-time-nav-bar.component';
import { AddLinkDialogComponent } from './components/add-link-dialog/add-link-dialog.component';

const materials = [
  MatButtonModule,
  MatCardModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatProgressSpinnerModule,
  MatSelectModule,
  MatSidenavModule,
  MatFormFieldModule,
  MatToolbarModule,
  MatRadioModule,
  MatMenuModule,
  MatDialogModule,
];

@NgModule({
  declarations: [
    ScheduleCardComponent,
    ScheduleListComponent,
    CustomUkrainianDatePipe,
    TaskTypePipe,
    DateTimeNavBarComponent,
    AddLinkDialogComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    EffectsModule.forFeature([UserEffects]),
    ...materials,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    ...materials,
    FormsModule,
    ReactiveFormsModule,
    ScheduleListComponent,
    ScheduleCardComponent,
    TaskTypePipe,
    CustomUkrainianDatePipe,
    DateTimeNavBarComponent,
    AddLinkDialogComponent
  ],
  providers:[DatePipe]
})
export class SharedModule { }
