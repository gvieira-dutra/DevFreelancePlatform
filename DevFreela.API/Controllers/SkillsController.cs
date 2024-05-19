using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("api/skills")]
        public IActionResult GetAllSkills()
        {
            var skills = _skillService.SkillGetAll();

            return Ok(skills);
        }
    }
}
