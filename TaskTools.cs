using System.ComponentModel;

public class TaskTools
{
    private readonly List<TaskItem> _tasks = new();

    [Description("Add a new task to the user's task list.")]
    public string AddTask(
        [Description("The title of the task to add.")]
        string title)
    {
        var task = new TaskItem
        {
            Id = _tasks.Count + 1,
            Title = title,
            Completed = false
        };

        _tasks.Add(task);

        return $"Task {task.Id} added: {task.Title}";
    }

    [Description("Return all tasks currently in the user's task list.")]
    public List<TaskItem> ListTasks()
    {
        return _tasks;
    }

    [Description("Mark an existing task as completed.")]
    public string CompleteTask(
        [Description("The ID of the task to complete.")]
        int id)
    {
        var task = _tasks.FirstOrDefault(x => x.Id == id);

        if (task is null)
        {
            return $"Task {id} was not found.";
        }

        task.Completed = true;

        return $"Task {id} completed.";
    }
}