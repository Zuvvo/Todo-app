export class UpdateTodoDTO {
  public title: string;
  public description: string;
  public isDone: boolean;

  constructor(title: string, description: string, isDone: boolean) {
    this.title = title;
    this.description = description;
    this.isDone = isDone;
  }
}