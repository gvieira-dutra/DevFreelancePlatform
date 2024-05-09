using Microsoft.AspNetCore.Mvc;
using DevFreela.Models;
using Microsoft.Extensions.Options;

namespace DevFreela.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        public ProjectsController(IOptions<OpeningTimeOption> option)
        {
            _option = option.Value;
        }

        //api/projects?query=asp.net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            //get all projects
            return Ok();
        }

        //api/projects/id
        [HttpGet("id")]
        //[Route("api")]
        public IActionResult GetById(int id)
        {
            //get project by id
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {

            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            //create new project

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        // api/projects/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }

            //update obj

            return NoContent();

        }

        // api/projects/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // search, if it doesn't exist return NotFound

            // Remove object

            return NoContent();
        }

        // api/project/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        // api/project/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // api/project/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
