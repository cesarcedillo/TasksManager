using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PerfectChannel.Infrastructure.Repositories;
using System;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowOrigin")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("")]
        public IActionResult GetTasks()
        {
            try
            {
                var tasks = _taskRepository.GetTasks();
                var iactionresult = Ok(tasks);
                return iactionresult;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("")]
        public IActionResult UpdateTask(Domain.Task task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest("Invalid task value");
                }
                _taskRepository.UpdateTask(task);
                return Ok("The task was updated sucessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        public IActionResult AddTask(Domain.Task task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest("Invalid task value");
                }
                _taskRepository.AddTask(task);
                return Ok("The task was added sucessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}