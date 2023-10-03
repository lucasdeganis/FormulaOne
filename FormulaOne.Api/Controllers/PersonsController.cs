using FormulaOne.Api.Helpers;
using FormulaOne.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FormulaOne.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly IPersonsApplication _personsApplication;
        private readonly AppSettings _appSettings;
        public PersonsController(IPersonsApplication personsApplication, IOptions<AppSettings> appSettings)
        {
            _personsApplication = personsApplication;
            _appSettings = appSettings.Value;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _personsApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
