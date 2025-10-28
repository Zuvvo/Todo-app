import { Routes } from '@angular/router';
import { Todo } from './todo/todo';

export const routes: Routes = [
  { path: '', redirectTo: '/todo', pathMatch: 'full' },
  { path: 'todo', component: Todo },
];