using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_manager.Context;
using task_manager.Domain;
using task_manager.Repository;

namespace task_manager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public ProjectsController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerator<Project>> Get()
        {
            return Ok(_context.ProjectRepository.Get().ToList());
        }

        [HttpGet]
        [Route("GetProjectById/{projectId}")]
        public ActionResult<Project> GetProjectById(string projectId)
        {
            return Ok(_context.ProjectRepository.GetById(x => x.ProjectId.Equals(projectId)));
        }

        [HttpGet]
        [Route("GetProjectUsers/{projectId}")]
        public ActionResult<Project> GetProjectUsers(string projectId)
        {
            return Ok(_context.ProjectRepository.GetProjectsUsers(projectId));

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
