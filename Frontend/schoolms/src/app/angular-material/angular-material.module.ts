import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const materialModules = [
  //CdkTreeModule,
  //MatAutocompleteModule,
  MatButtonModule,
  MatCardModule,
  //MatCheckboxModule,
  //MatChipsModule,
  //MatDividerModule,
  //MatExpansionModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  //MatMenuModule,
  MatProgressSpinnerModule,
  //MatPaginatorModule,
  //MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  //MatSnackBarModule,
  //MatSortModule,
  //MatTableModule,
  //MatTabsModule,
  //MatToolbarModule,
  MatFormFieldModule,
  //MatButtonToggleModule,
  //MatTreeModule,
  //OverlayModule,
  //PortalModule,
  //MatBadgeModule,
  //MatGridListModule,
  //MatRadioModule,
  //MatDatepickerModule,
  //MatTooltipModule
];

@NgModule({
  declarations: [], 
  imports: [
    CommonModule,
    ...materialModules,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    ...materialModules,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AngularMaterialModule { }
