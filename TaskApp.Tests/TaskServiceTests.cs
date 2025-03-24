using Xunit;
using TaskApp.Models;
using TaskApp.Services;
using TaskApp.Dtos;

namespace TaskApp.Tests;

public class TaskServiceTests
{
    private readonly TaskService _service;

    public TaskServiceTests()
    {
        _service = new TaskService();
    }

    [Fact]
    public void Create_ShouldAssignIncrementingId()
    {
        var task = new TaskItem { Title = "Test Task" };

        var result = _service.Create(task);

        Assert.Equal(1, result.Id);
        Assert.Equal("Test Task", result.Title);
    }

    [Fact]
    public void GetAll_ShouldReturnAllTasks()
    {
        _service.Create(new TaskItem { Title = "One" });
        _service.Create(new TaskItem { Title = "Two" });

        var tasks = _service.GetAll();

        Assert.Equal(2, tasks.Count());
    }

    [Fact]
    public void GetById_ShouldReturnCorrectTask()
    {
        var task = _service.Create(new TaskItem { Title = "Find me" });

        var found = _service.GetById(task.Id);

        Assert.NotNull(found);
        Assert.Equal("Find me", found?.Title);
    }

    [Fact]
    public void GetById_WithInvalidId_ReturnsNull()
    {
        var result = _service.GetById(999);
        Assert.Null(result);
    }

    [Fact]
    public void Update_ShouldModifyTask()
    {
        var original = _service.Create(new TaskItem { Title = "Before" });

        var updated = new TaskItem { Title = "After", Description = "Updated", IsComplete = true };
        var success = _service.Update(original.Id, updated);
        var result = _service.GetById(original.Id);

        Assert.True(success);
        Assert.Equal("After", result?.Title);
        Assert.Equal("Updated", result?.Description);
        Assert.True(result?.IsComplete);
    }

    [Fact]
    public void Update_WithNonExistingId_ReturnsFalse()
    {
        var updated = new TaskItem { Title = "Updated", Description = "...", IsComplete = true };
        var result = _service.Update(999, updated);
        Assert.False(result);
    }

    [Fact]
    public void Delete_ShouldRemoveTask()
    {
        var task = _service.Create(new TaskItem { Title = "Test Task" });

        var success = _service.Delete(task.Id);
        var result = _service.GetById(task.Id);

        Assert.True(success);
        Assert.Null(result);
    }

    [Fact]
    public void Delete_WithNonExistingId_ReturnsFalse()
    {
        var result = _service.Delete(999);
        Assert.False(result);
    }

    [Fact]
    public void Update_ShouldReturnFalse_WhenTaskDoesNotExist()
    {
        var result = _service.Update(99, new TaskItem { Title = "Won't Work" });

        Assert.False(result);
    }

    [Fact]
    public void Delete_ShouldReturnFalse_WhenTaskDoesNotExist()
    {
        var result = _service.Delete(99);

        Assert.False(result);
    }
}
