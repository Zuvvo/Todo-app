import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TodoService } from '../services/todoservice';
import { TodoDTO } from '../dto/todoDTO';
import { AddTodoDialogComponent } from '../add-todo-dialog/add-todo-dialog.component';
import { MatCard } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-todos',
  standalone: true,
  imports: [MatCard, MatTableModule],
  templateUrl: './todos.component.html',
  styleUrl: './todos.component.css'
})

export class TodosComponent {

  todos: TodoDTO[] = [];

  constructor(private todoService: TodoService, private dialog: MatDialog) { }

  getTodos() {
  this.todoService.getTodos().subscribe(
    (response) => {
      this.todos = response;
    },
    (error) => {
      console.error(error);
    }
  );
}

  openAddTodoDialog() {
  const dialogRef = this.dialog.open(AddTodoDialogComponent, {
    width: '400px',
    data: {
      title: '',
      description: '',
      done: false
    }
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      this.todoService.postTodo(result).subscribe(
        (response) => {
          this.getTodos();
        },
        (error) => {
          console.error(error);
        }
      );
    }
  });
}
}