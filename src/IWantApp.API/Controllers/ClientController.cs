using IWantApp.Application.Contracts;
using IWantApp.Application.DTO.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IWantApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserIdentityService _userIdentityService;

        public ClientController(UserManager<IdentityUser> userManager, IUserIdentityService userIdentityService)
        {
            _userManager = userManager;
            _userIdentityService = userIdentityService;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(ClienteRequest model)
        {
            var userClaims = new List<Claim>
            {
                new Claim("Cpf", model.CPF),
                new Claim("Name", model.Name)
            };

            (IdentityResult result, string userId) = await _userIdentityService.CreateUserAsync(model.Email, model.Password, userClaims);
            
            if (!result.Succeeded) 
                return BadRequest("Fail to create user: " + result.Errors.First().Description);


            return Created($"/client/{userId}", userId);

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = User.Claims;//.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var result = new
            {
                Id = user.First(c => c.Type == ClaimTypes.NameIdentifier).Value,
                Name = user.First(c => c.Type == "Name").Value,
                //Cpf = user.First(c => c.Type == "Cpf").Value,
            };

            return Ok(result);

        }
    }
}
