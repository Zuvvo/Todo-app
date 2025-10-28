import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddTodoDTO } from '../dto/addTodoDTO';
import { UpdateTodoDTO } from '../dto/updateTodoDTO';
import { TodoDTO } from '../dto/todoDTO';


@Injectable({
  providedIn: 'root'
})


export class TodoService {
  private apiUrl = 'https://localhost:44314/api';

  constructor(private http: HttpClient) { }

  getTodos(): Observable<TodoDTO[]> {
    return this.http.get<TodoDTO[]>(`${this.apiUrl}/todos`);
  }

  getTodo(id: number): Observable<TodoDTO> {
    return this.http.get<TodoDTO>(`${this.apiUrl}/todos/${id}`);
  }

  putTodo(id: number, updateTodoDTO: UpdateTodoDTO): Observable<TodoDTO> {
    return this.http.put<TodoDTO>(`${this.apiUrl}/todos/${id}`, updateTodoDTO);
  }

  postTodo(addTodoDTO: AddTodoDTO): Observable<TodoDTO> {
    return this.http.post<TodoDTO>(`${this.apiUrl}/todos`, addTodoDTO);
  }

  deleteTodo(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/todos/${id}`);
  }

  markTodoAsDone(id: number): Observable<TodoDTO> {
    return this.http.patch<TodoDTO>(`${this.apiUrl}/todos/${id}/done`, {});
  }
}