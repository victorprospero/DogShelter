using Authenticator.Domain;
using Authenticator.Domain.Entities;
using Authenticator.Domain.Models;
using Authenticator.Infrastructure.Contexts;
using LinqKit;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace Authenticator.Infrastructure.Repositories
{
    public class AuthenticatorRepository(AuthenticatorContext dbContext, IDataProtectionProvider dataProtectionProvider) : IAuthenticatorRepository
    {
        private readonly IDataProtectionProvider dataProtectionProvider = dataProtectionProvider;
        private readonly AuthenticatorContext dbContext = dbContext;
        public async Task CreateSampleDatabaseAsync()
        {
            RoleModel[] roles = [
                new RoleModel { Name = "Read" }, 
                new RoleModel { Name = "Write" }
            ];

            UserModel[] users = [
                new UserModel{
                    Email = "victorprospero@hotmail.com",
                    Password = "12345",
                    Roles = [roles[0], roles[1]]
                },
                new UserModel{
                    Email = "miguel.carvalo@gmail.com",
                    Password = "67890",
                    Roles = [roles[0]]
                },
            ];
            foreach (var role in roles)
            {
                await AddRole(role);
            }
            foreach (var user in users)
            {
                await AddUser(user);
                foreach (var role in user.Roles ?? [])
                {
                    await GrantAccess(user.Email, role.Id);
                }
            }
        }

        private async Task AddUser(UserModel user)
        {
            User newUser = dbContext.CreateProxy<User>();
            newUser.Email = user.Email;
            var protector = dataProtectionProvider.CreateProtector(string.Empty);
            newUser.Password = protector.Protect(user.Password ?? string.Empty);
            await dbContext.Users.AddAsync(newUser);
        }

        private async Task<RoleModel> AddRole(RoleModel role)
        {
            Role newRole = dbContext.CreateProxy<Role>();
            newRole.Name = role.Name ?? string.Empty;
            await dbContext.Roles.AddAsync(newRole);
            role.Id = newRole.Id;
            return role;
        }

        private async Task GrantAccess(string? eMail, uint? roleId)
        {
            UserRole grant = dbContext.CreateProxy<UserRole>();
            grant.Email = eMail ?? string.Empty;
            grant.RoleId = roleId ?? 0;
            await dbContext.UsersRoles.AddAsync(grant);
        }

        public async Task<IEnumerable<UserModel>> ListUsersAsync()
        {
            return await (from a in dbContext.Users.AsExpandable()
                          select new UserModel()
                          {
                              Email = a.Email,
                              Password = a.Password,
                              Roles = (from b in a.Roles
                                       select new RoleModel()
                                       {
                                           Id = b.RoleId,
                                           Name = b.Role.Name
                                       })
                          }).ToListAsync();
        }
    }
}
