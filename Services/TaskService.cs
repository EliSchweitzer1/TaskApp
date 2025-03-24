using TaskApp.Models;

namespace TaskApp.Services;

public class TaskService : ITaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public IEnumerable<TaskItem> GetAll() => _tasks;

    public TaskItem? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

    public TaskItem Create(TaskItem task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
        return task;
    }

    public bool Update(int id, TaskItem updatedTask)
    {
        var existing = GetById(id);
        if (existing == null){
            return false;
        }

        existing.Title = updatedTask.Title;
        existing.Description = updatedTask.Description;
        existing.IsComplete = updatedTask.IsComplete;
        return true;
    }

    public bool Delete(int id)
    {
        var task = GetById(id);
        if (task == null) 
        {
            return false;
        }

        _tasks.Remove(task);
        return true;
    }

}