namespace TodoApp.DTO
{
    public class UpdateTodoDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsDone { get; set; }
    }
}
