using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //api/projects?query=asp.net core
        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetAll(string queryStr)
        {
            var myQuery = new GetAllProjectsQuery(queryStr);

            var projects = await _mediator.Send(myQuery);

            return Ok(projects);
        }

        //api/projects/id
        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetOne(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetOne), new { id = id }, command);
        }

        // api/projects/update/id
        [HttpPut("update/{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/project/1/comments
        [HttpPost("comments/{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/project/start/1
        [HttpPut("start/{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
        
        // api/project/1/finish
        [HttpPut("finish/{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
        
        // api/projects/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
