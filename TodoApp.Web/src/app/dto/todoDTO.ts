export class TodoDTO {
  public id: number;
  public title: string;
  public description: string;
  public isDone: boolean;

  constructor(id: number, title: string, description: string, isDone: boolean) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.isDone = isDone;
  }
}