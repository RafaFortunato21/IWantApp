using IWantApp.Application.DTO.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IWantApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenController> _logger;

        public TokenController(UserManager<IdentityUser> userManager, IConfiguration configuration, ILogger<TokenController> logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost(Name = "login")]
        [AllowAnonymous]
        public ActionResult Post(LoginRequestDTO model)
        {
            _logger.LogInformation("Getting Token");
            _logger.LogWarning("Getting Token");
            _logger.LogError("Getting Token");


            var user = _userManager.FindByEmailAsync(model.Email).Result;

            if (user == null)
                return BadRequest();

            if (!_userManager.CheckPasswordAsync(user, model.Password).Result)
                return BadRequest();

            var privatekey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(_configuration["JwtToken:Secretkey"]));

            var claims = _userManager.GetClaimsAsync(user).Result;

            var subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Email, model.Email),
                     new Claim(ClaimTypes.NameIdentifier, user.Id)
               });

            subject.AddClaims(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                SigningCredentials = new SigningCredentials(privatekey, SecurityAlgorithms.HmacSha256),
                Audience = _configuration["JwtToken:Audience"],
                Issuer = _configuration["JwtToken:Issuer"]
                //Expires = DateTime.UtcNow.AddSeconds(20)
                
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });

        }
    }
}
