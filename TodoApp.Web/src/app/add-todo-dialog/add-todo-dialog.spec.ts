import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTodoDialog } from './add-todo-dialog';

describe('AddTodoDialog', () => {
  let component: AddTodoDialog;
  let fixture: ComponentFixture<AddTodoDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddTodoDialog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddTodoDialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
