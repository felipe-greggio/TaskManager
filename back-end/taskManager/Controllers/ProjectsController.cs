using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using task_manager.Context;
using task_manager.Domain;
using task_manager.DTOs;
using task_manager.Repository;
using task_manager.Response;

namespace task_manager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public ProjectsController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           
        }

        [HttpGet]
        [Route("GetAllProjects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {

            var projects = await _context.ProjectRepository.Get().ToListAsync();
            var projectsDto = _mapper.Map<List<ProjectDTO>>(projects);


            return Ok(projectsDto);
        }

        [HttpGet]
        [Route("GetProjectById/{projectId}")]
        public async Task<ActionResult<ProjectDTO>> GetProjectById(Guid projectId)
        {
            var project =  await _context.ProjectRepository.GetById(x => x.ProjectId.Equals(projectId));

            var projectDto = _mapper.Map<ProjectDTO>(project);

            return Ok(projectDto);
        }

        [HttpGet]
        [Route("GetProjectInfo/{projectId}")]
        public async Task<ActionResult<ProjectDTO>> GetProjectUsers(Guid projectId)
        {

            var project = await _context.ProjectRepository.GetProjectByIdIncludeUsersAndTasks(projectId);

            var projectDto = _mapper.Map<ProjectDTO>(project);

            return Ok(projectDto);

        }

        [HttpPost]
        public async Task<ResponseResult> RegisterProject([FromBody] Project project)
        {
            try
            {
                project.ProjectId = new Guid();
                project.Status = Domain.Enums.EnumProjectStatus.Ongoing;
                _context.ProjectRepository.Add(project);
                _context.Commit();

                return ResponseResult.ReturnSuccess("RequestSuccessFull", project);
            }
            catch (Exception)
            {
                return ResponseResult.ReturnError("Ocorreu um problema ao tratar sua solicitação");
            }
        }

        [HttpPut]
        [Route("UpdateProject/{projectId}")]
        public async Task<ActionResult<Project>> Put(string projectId, Project project)
        {

            if (!project.ProjectId.Equals(projectId))
            {
                return BadRequest("Ids não equivalentes");
            }

            _context.ProjectRepository.Update(project);
           await _context.Commit();

            return Ok(project);
        }

        [HttpDelete]
        [Route("DeleteProject/{projectId}")]
        public async Task<ActionResult<Project>> Delete(string projectId)
        {

            var project = await _context.ProjectRepository.GetById(x => x.ProjectId.Equals(projectId));

            _context.ProjectRepository.Delete(project);
            await _context.Commit();

            return Ok(project);
        }


    }
}
