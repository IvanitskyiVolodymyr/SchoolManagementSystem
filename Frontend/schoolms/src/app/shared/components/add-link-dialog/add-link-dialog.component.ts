import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { addStudentTaskAttachments } from 'src/app/store/actions/student.actions';
import { StudentTaskAttachment } from '../../models/attachments/studentTaskAttachment';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-add-link-dialog',
  templateUrl: './add-link-dialog.component.html',
  styleUrls: ['./add-link-dialog.component.scss']
})
export class AddLinkDialogComponent {
  
  public attachment: StudentTaskAttachment = {} as StudentTaskAttachment;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,//eslint-disable-line
    private store: Store
  ) { }

  public linkForm : FormGroup = new FormGroup({
    link: new FormControl('',[
      Validators.required,
      Validators.pattern(/((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)/)//eslint-disable-line
    ]),
  });

  public addLinkClicked() {
    console.log(this.data);
    this.store.dispatch(addStudentTaskAttachments({studentTaskId: this.data.studentTaskId, attachment: this.attachment}));
  }
}
