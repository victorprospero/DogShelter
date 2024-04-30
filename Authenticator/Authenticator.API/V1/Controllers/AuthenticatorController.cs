using Authenticator.Application.Commands;
using Authenticator.Application.Models;
using Authenticator.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authenticator.API.V1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]/[action]")]
    public class AuthenticatorController(IMediator mediator, IConfiguration configuration)
    {
        private readonly IMediator mediator = mediator;
        private readonly IConfiguration configuration = configuration;
        
        [HttpGet]
        public async Task<object> GetToken(string email, string password)
        {
            string result = "OK", stringToken = "";
            IEnumerable<UserAppModel>? users = await mediator.Send(new ListUsersQuery());
            UserAppModel user = users?.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                result = "NotFound";
            }
            else
            {
                var ci = new ClaimsIdentity();
                ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                foreach (string role in user.Roles)
                {
                    ci.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                JwtSecurityTokenHandler handler = new();
                byte[] key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("KeyGeneration:PrivateKey") ?? string.Empty);
                SigningCredentials credentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    SigningCredentials = credentials,
                    Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("KeyGeneration:MinutesToExpire")),
                    Subject = ci
                };
                SecurityToken token = handler.CreateToken(tokenDescriptor);
                stringToken = handler.WriteToken(token);
            }
            return new { result, token = stringToken };
        }

        [HttpGet]
        public async Task<IEnumerable<UserAppModel>?> InitializeUsers()
        {
            await mediator.Publish(new CreateSampleDatabaseCommand());
            return await mediator.Send(new ListUsersQuery());
        }
        
    }
}
