using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_manager.Context;
using task_manager.Domain;
using task_manager.DTOs;
using task_manager.Repository;

namespace task_manager.Controllers
{
    [Route("[controller]")]
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
        public ActionResult<IEnumerable<Project>> Get()
        {

            var projects = _context.ProjectRepository.Get().ToList();
            var projectsDto = _mapper.Map<List<ProjectDTO>>(projects);


            return Ok(projectsDto);
        }

        [HttpGet]
        [Route("GetProjectById/{projectId}")]
        public ActionResult<ProjectDTO> GetProjectById(string projectId)
        {
            var project =  _context.ProjectRepository.GetById(X => X.ProjectId.Equals(projectId));

            var projectDto = _mapper.Map<ProjectDTO>(project);

            return Ok(projectDto);
        }

        [HttpGet]
        [Route("GetProjectUsers/{projectId}")]
        public ActionResult<ProjectDTO> GetProjectUsers(string projectId)
        {

            var projectUsers = _context.ProjectRepository.GetProjectsUsers(x => x.ProjectId.Equals(projectId));

            var projectUsersDto = _mapper.Map<ProjectDTO>(projectUsers);

            return Ok(projectUsersDto);

        }

        [HttpPost]
        public ActionResult<Project> Post(Project project)
        {
            _context.ProjectRepository.Add(project);
            _context.Commit();

            return Ok(project);
        }

        [HttpPut]
        [Route("UpdateProject/{projectId}")]
        public ActionResult<Project> Put(string projectId, Project project)
        {

            if (!project.ProjectId.Equals(projectId))
            {
                return BadRequest("Ids não equivalentes");
            }

            _context.ProjectRepository.Update(project);
            _context.Commit();

            return Ok(project);
        }

        [HttpDelete]
        [Route("DeleteProject/{projectId}")]
        public ActionResult<Project> Delete(string projectId)
        {

            var project = _context.ProjectRepository.GetById(x => x.ProjectId.Equals(projectId));

            _context.ProjectRepository.Delete(project);
            _context.Commit();

            return Ok(project);
        }


    }
}
