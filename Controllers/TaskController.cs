using Microsoft.AspNetCore.Mvc;
using TaskApp.Models;
using TaskApp.Services;
using TaskApp.Dtos;

namespace TaskApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetAll() => Ok(_taskService.GetAll());

    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        if (id < 1){
            return BadRequest();
        }
        
        var task = _taskService.GetById(id);
        if (task == null) return NotFound();
        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskItem> Create(TaskDto dto)
    {
        if (!ModelState.IsValid){
            // Could return BadRequest(ModelState);
            // But that could expose info to bad actors
            return BadRequest();
        }

        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            IsComplete = dto.IsComplete
        };

        var created = _taskService.Create(task);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TaskDto dto)
    {
        if (id < 1){
            return BadRequest();
        }
        
        if (!ModelState.IsValid){
            return BadRequest();
        }

        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            IsComplete = dto.IsComplete
        };

        if (!_taskService.Update(id, task)){
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (id < 1){
            return BadRequest();
        }

        if (!_taskService.Delete(id)){
            return NotFound();
        }

        return NoContent();
    }
}
