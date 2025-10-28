import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TodoService } from '../services/todoservice';
import { TodoDTO } from '../dto/todoDTO';
import { AddTodoDialog } from '../add-todo-dialog/add-todo-dialog';
import { MatCard } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [MatCard, MatTableModule, MatButtonModule, MatIconModule, MatCheckboxModule],
  templateUrl: './todo.html',
  styleUrl: './todo.css'
})

export class Todo {

  todos: TodoDTO[] = [];

  constructor(private todoService: TodoService, private dialog: MatDialog) { }

    ngOnInit(): void {
    this.getTodos();
  }

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

markAsDone(id: number): void {
  this.todoService.markTodoAsDone(id).subscribe({
    next: (updatedTodo) => {
      const index = this.todos.findIndex(t => t.id === id);
      if (index !== -1) {
        this.todos[index] = { ...updatedTodo };
        this.todos = [...this.todos];
      }
    },
    error: (err) => console.error('Error marking todo as done:', err)
  });
}

deleteTodo(id: number) {
  if (confirm('Are you sure you want to delete this todo?')) {
    this.todoService.deleteTodo(id).subscribe({
      next: () => {
        this.todos = this.todos.filter(todo => todo.id !== id);
      },
      error: (err) => {
        console.error('Error deleting todo:', err);
      }
    });
  }
}

  openAddTodoDialog() {
  const dialogRef = this.dialog.open(AddTodoDialog, {
    width: '420px',
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