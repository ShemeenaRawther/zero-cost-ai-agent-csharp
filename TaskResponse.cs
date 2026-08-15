public class TaskResponse
{
    public string Message { get; set; } = string.Empty;

    public string Action { get; set; } = string.Empty;

    public List<TaskItem> Tasks { get; set; } = [];
}