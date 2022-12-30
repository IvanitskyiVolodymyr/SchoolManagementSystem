import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-comment-form',
  templateUrl: './comment-form.component.html',
  styleUrls: ['./comment-form.component.scss']
})
export class CommentFormComponent implements OnInit{
  @Input() submitLabel!: string;
  @Input() hasCancelButton = false;
  @Input() initialText = '';

  @Output() handleSubmit = new EventEmitter<string>();
  @Output() cancelClicked = new EventEmitter();

  form!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      title: [this.initialText, Validators.required],
    });
  }

  onSubmit(): void {
    this.handleSubmit.emit(this.form.value.title);
    this.form.reset();
  }

  onCancel() {
    this.cancelClicked.emit();
    this.form.reset();
  }
}
