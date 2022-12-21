import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatMenuTrigger } from '@angular/material/menu';

@Component({
  selector: 'app-task-info',
  templateUrl: './task-info.component.html',
  styleUrls: ['./task-info.component.scss']
})
export class TaskInfoComponent {

  @ViewChild('menuTrigger') menuTrigger: MatMenuTrigger = {} as MatMenuTrigger;

  constructor(public dialog: MatDialog) {}

  openAttachLinkDialog() {
    //const dialogRef = this.dialog.open(DialogFromMenuExampleDialog, {restoreFocus: false});

    // Manually restore focus to the menu trigger since the element that
    // opens the dialog won't be in the DOM any more when the dialog closes.
    //dialogRef.afterClosed().subscribe(() => this.menuTrigger.focus());
  }

}
