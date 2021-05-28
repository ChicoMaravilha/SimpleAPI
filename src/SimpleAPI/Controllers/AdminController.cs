using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SimpleAPI.Model;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
      
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] User user)
        {
            var claims = new List<Claim>
            {
                new Claim("type","Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));
            var Token = new JwtSecurityToken(
                "https://SimpleAPI.com",
                "https://SimpleAPI.com",
                claims,
                    expires: DateTime.Now.AddDays(30.0),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(Token));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy="Admin")]
        public IActionResult GenerateBadge([FromBody] Agent agent)
        {
            var claims = new List<Claim>
            {
                new Claim("type", "Agent"),
                new Claim("ClearanceLevel", agent.ClearanceLevel.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));
            var Token = new JwtSecurityToken(
                "https://SimpleAPI.com",
                "https://SimpleAPI.com",
                claims,
                    expires: DateTime.Now.AddDays(30.0),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(Token));
        }
    }
}
