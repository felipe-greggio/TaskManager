using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using task_manager.Domain;
using task_manager.Domain.Enums;
using task_manager.DTOs;
using task_manager.Extensions;
using task_manager.Repository;
using task_manager.Response;

namespace task_manager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TasksController(IUnitOfWork context, ILogger<TasksController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetTasksByUser")]
        public async Task<ResponseResult> GetTasksByUserId([FromBody] string userId)
        {
            try
            {

                _logger.LogInformation("==============GET api/tasks/GetTasksByUserId================");
                var tasks = _context.TasksRepository.GetTasksByUser(userId);

                if (tasks is null)
                {
                    return ResponseResult.ReturnNotFound("No Tasks found for this user", tasks);
                }

                var tasksDto = _mapper.Map<List<TaskDTO>>(tasks);

                return ResponseResult.ReturnSuccess("Request Successful",tasksDto);
            }
            catch (Exception)
            {
                return ResponseResult.ReturnError("Something went wrong.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetTasksByProject/{projectId}")]
        public async Task<ResponseResult> GetTasksByProjectId(string projectId)
        {
            try
            {

                _logger.LogInformation("==============GET api/tasks/GetTasksByUserId================");
                var tasks = _context.TasksRepository.GetTasksByProject(projectId);

                if (tasks is null)
                {
                    return ResponseResult.ReturnNotFound("No Tasks found for this user", tasks);
                }

                var tasksDto = _mapper.Map<List<TaskDTO>>(tasks);

                return ResponseResult.ReturnSuccess("Request Successful", tasksDto);
            }
            catch (Exception)
            {
                return ResponseResult.ReturnError("Something went wrong.");
            }
        }

        [HttpPost]
        [Route("RegisterNewTask")]
        public async Task<ResponseResult> RegisterNewTask([FromBody] Domain.Task task)
        {

            try
            {
                task.Status = EnumTaskStatus.NotStarted;
                _context.TasksRepository.Add(task);
                await _context.Commit();

                return ResponseResult.ReturnSuccess("Created a new task", task);
            }
            catch (Exception)
            {
                return ResponseResult.ReturnError("Something went wrong.");
            }
        }

        [HttpPut]
        [Route("UpdateTask/{taskId}")]
        public async Task<ResponseResult> UpdateUser(string taskId, Domain.Task task)
        {
            try
            {
                if (task.TaskId.ToString() != taskId)
                {
                    return ResponseResult.ReturnFail("Ids dont match");
                }

                _context.TasksRepository.Update(task);
                await _context.Commit();

                return ResponseResult.ReturnSuccess("Task updated", task);
            }
            catch (Exception)
            {
                return ResponseResult.ReturnFail("Something went wrong. Task not updated");
            }
        }

        [HttpDelete]
        [Route("DeleteTask/{taskId}")]
        public async Task<ResponseResult> DeleteTask(string taskId)
        {

            try
            {
                var deletedTask = await _context.TasksRepository.GetById(x => x.TaskId.ToString() == taskId);

                if (deletedTask is null)
                {
                    return ResponseResult.ReturnNotFound("Task not located");
                }

                _context.TasksRepository.Delete(deletedTask);
                _context.Commit();

                return ResponseResult.ReturnSuccess("Task Deleted");
            }
            catch (Exception)
            {
                return ResponseResult.ReturnError("Something went wrong. Task not deleted");
            }
        }
    }
}
