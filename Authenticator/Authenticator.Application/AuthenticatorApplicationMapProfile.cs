using Authenticator.Application.Models;
using Authenticator.Domain.Models;
using AutoMapper;

namespace Authenticator.Application
{
    public class AuthenticatorApplicationMapProfile : Profile
    {
        public AuthenticatorApplicationMapProfile()
        {
            CreateMap<UserModel, UserAppModel>()
                .ForMember(a => a.Roles, b => b.MapFrom(c => c.Roles == null ? new string[] { } : c.Roles.Select(x => x.Name)));
        }
    }
}
