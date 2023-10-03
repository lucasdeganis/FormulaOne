using FormulaOne.Api.Helpers;
using FormulaOne.Application.Business;
using FormulaOne.Application.Interfaces;
using FormulaOne.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FormulaOne.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriversApplication _driversApplication;
        private readonly AppSettings _appSettings;
        public DriversController(IDriversApplication driversApplication, IOptions<AppSettings> appSettings)
        {
            _driversApplication = driversApplication;
            _appSettings = appSettings.Value;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] DriverDto driverDto)
        {
            if (driverDto == null)
                return BadRequest();
            var response = await _driversApplication.InsertAsync(driverDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("Get/{driverId}")]
        public async Task<IActionResult> GetAsync(Guid driverId)
        {
            var response = await _driversApplication.GetAsync(driverId);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {                    
                    return Ok(response);
                }
                else
                    return NotFound(response);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _driversApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
