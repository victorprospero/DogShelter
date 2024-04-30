using AutoMapper;
using DogShelter.API.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DogShelter.API.V1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]/[action]")]
    public class AuthenticatorController(ILogger<DogShelterController> logger, IMapper mapper, IMediator mediator, IConfiguration configuration) : DogShelterControllerBase<DogShelterController>(logger, mapper, mediator)
    {
        private readonly IConfiguration configuration = configuration;

        [HttpGet]
        public string GetToken()
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, "victorprospero@hotmail.com"));
            ci.AddClaim(new Claim(ClaimTypes.Role, "Read"));
            ci.AddClaim(new Claim(ClaimTypes.Role, "Write"));

            JwtSecurityTokenHandler handler = new();
            byte[] key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("PrivateKey") ?? string.Empty);
            SigningCredentials credentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddMinutes(30),
                Subject = ci
            };
            
            SecurityToken token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
