using Dapper;
using IWantApp.Application.Contracts;
using IWantApp.Application.DTO;
using IWantApp.Application.DTO.Identity;
using IWantApp.Application.Services;
using IWantApp.Application.Services.UserIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Claims;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IWantApp.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EmployeePolicy")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(Policy = "EmployeePolicy")]
    //[AllowAnonymous]
    public class EmployeeController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeService _employeeService;
        private readonly IUserIdentityService _userIdentityService;

        public EmployeeController(UserManager<IdentityUser> userManager, 
                                  IConfiguration configuration,
                                  IEmployeeService employeeService,
                                  IUserIdentityService userIdentityService
                                  )
        {
            _userManager = userManager;
            _configuration = configuration;
            _employeeService = employeeService;
            _userIdentityService = userIdentityService;
        }
        // GET: api/<EmpolyeesController>
        [HttpGet]
        public async Task<IActionResult> Get(int page, int rows)
        {
            var employees = await _employeeService.GetEmployees(page, rows);
            
            return Ok(employees);
        }

       

        // POST api/<EmpolyeesController>
        [HttpPost(Name = "Register")]

        public async Task<IActionResult> Post([FromBody] EmployeeRequestDTO employeeDto)
        {
            var userClaims = new List<Claim>
            {
                new Claim("EmployeeCode", employeeDto.EmployeeCode),
                new Claim("Name", employeeDto.Name)

            };

            (IdentityResult result, string userId) = await _userIdentityService
                                                                .CreateUserAsync(employeeDto.Email, employeeDto.Password, userClaims);
            
            if (!result.Succeeded)
                return BadRequest(result.Errors.First());

            

            return Created($"/employee/{userId}", userId);

        }

      

       
    }
}
