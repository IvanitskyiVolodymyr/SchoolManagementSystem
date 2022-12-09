import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { EffectsModule } from '@ngrx/effects';
import { UserEffects } from '../store/effects/user.effects';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
];

@NgModule({
  declarations: [],
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
    ReactiveFormsModule
  ]
})
export class SharedModule { }
