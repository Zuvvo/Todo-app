import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-add-todo-dialog',
  standalone: true,
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './add-todo-dialog.html',
  styleUrls: ['./add-todo-dialog.css'],
})
export class AddTodoDialog {
  title: string = '';
  description: string = '';

  constructor(private dialogRef: MatDialogRef<AddTodoDialog>) {}

  save() {
    if (this.title.trim()) {
      this.dialogRef.close({
        title: this.title,
        description: this.description,
        done: false
      });
    }
  }

  cancel() {
    this.dialogRef.close();
  }
}