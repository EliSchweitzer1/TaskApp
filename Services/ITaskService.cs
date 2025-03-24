using TaskApp.Models;

namespace TaskApp.Services;

public interface ITaskService
{
    IEnumerable<TaskItem> GetAll();
    TaskItem? GetById(int id);
    TaskItem Create(TaskItem task);
    bool Update(int id, TaskItem updatedTask);
    bool Delete(int id);
}