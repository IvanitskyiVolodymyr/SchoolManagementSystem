import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatMenuTrigger } from '@angular/material/menu';
import { AddLinkDialogComponent } from 'src/app/shared/components/add-link-dialog/add-link-dialog.component';

@Component({
  selector: 'app-task-info',
  templateUrl: './task-info.component.html',
  styleUrls: ['./task-info.component.scss']
})
export class TaskInfoComponent {

  @ViewChild('addAttachmentTrigger') attachmentTrigger: MatMenuTrigger = {} as MatMenuTrigger;

  constructor(public dialog: MatDialog) {}

  openAttachLinkDialog() {
    const dialogRef = this.dialog.open(AddLinkDialogComponent, {restoreFocus: false});
    dialogRef.afterClosed().subscribe(() => this.attachmentTrigger.focus());
  }

}
