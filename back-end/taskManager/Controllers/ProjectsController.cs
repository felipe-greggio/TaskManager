using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_manager.Context;
using task_manager.Domain;

namespace task_manager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerator<Project>> Get()
        {
            return Ok(_context.Projects.AsNoTracking().ToList());
        }

        [HttpGet]
        [Route("GetProjectById/{projectId}")]
        public ActionResult<Project> GetProjectById(string projectId)
        {
            return Ok(_context.Projects.AsNoTracking().FirstOrDefault(x => x.ProjectId.Equals(projectId)));
        }


        [HttpPost]
        public ActionResult<Project> Post(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();

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

            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(project);
        }

        [HttpDelete]
        [Route("DeleteProject/{projectId}")]
        public ActionResult<Project> Delete(string projectId)
        {

            var project = _context.Projects.FirstOrDefault(x => x.ProjectId.Equals(projectId));

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return Ok(project);
        }


    }
}
