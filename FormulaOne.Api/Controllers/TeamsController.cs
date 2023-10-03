using FormulaOne.Api.Helpers;
using FormulaOne.Application.Interfaces;
using FormulaOne.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FormulaOne.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private readonly ITeamsApplication _teamsApplication;
        private readonly AppSettings _appSettings;
        public TeamsController(ITeamsApplication teamsApplication, IOptions<AppSettings> appSettings)
        {
            _teamsApplication = teamsApplication;
            _appSettings = appSettings.Value;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _teamsApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
