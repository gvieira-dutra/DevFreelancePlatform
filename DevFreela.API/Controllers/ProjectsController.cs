using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        //api/projects?query=asp.net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            //get all projects
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        //api/projects/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //get project by id
            var project = _projectService.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // api/project/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if (inputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = _projectService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        // api/projects/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectService.Update(inputModel);

            return NoContent();
        }

        // api/project/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        // api/project/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService?.Delete(id);

            return NoContent();
        }
    }
}