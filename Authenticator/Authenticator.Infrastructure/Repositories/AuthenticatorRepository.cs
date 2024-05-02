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
        private readonly IDataProtector passwordProtector = dataProtectionProvider.CreateProtector("User Password");
        private readonly AuthenticatorContext dbContext = dbContext;
        public async Task CreateSampleDatabaseAsync()
        {
            User[] users = [await AddUser(new UserModel() { Email = "victorprospero@hotmail.com", Password = "12345"}),
                            await AddUser(new UserModel() { Email = "miguel.carvalho@gmail.com", Password = "67890"})];
            Role[] roles = [await AddRole(new RoleModel() { Name = "Read" }),
                            await AddRole(new RoleModel() { Name = "Write" })];
            await GrantAccess(users[0], roles[0]);
            await GrantAccess(users[0], roles[1]);
            await GrantAccess(users[1], roles[0]);
            await dbContext.SaveChangesAsync();
        }

        private async Task<User> AddUser(UserModel user)
        {
            User newUser = dbContext.CreateProxy<User>();
            newUser.Email = user.Email ?? string.Empty;
            newUser.Password = passwordProtector.Protect(user.Password ?? string.Empty);
            await dbContext.Users.AddAsync(newUser);
            return newUser;
        }

        private async Task<Role> AddRole(RoleModel role)
        {
            Role newRole = dbContext.CreateProxy<Role>();
            newRole.Name = role.Name ?? string.Empty;
            await dbContext.Roles.AddAsync(newRole);
            role.Id = newRole.Id;
            return newRole;
        }

        private async Task GrantAccess(User user, Role role)
        {
            UserRole grant = dbContext.CreateProxy<UserRole>();
            grant.Email = user.Email;
            grant.User = user;
            grant.RoleId = role.Id;
            grant.Role = role;
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
        public async Task<UserModel?> GetUserAsync(string eMail, string password)
        {
            UserModel? user = await (from a in dbContext.Users.AsExpandable()
                              where a.Email == eMail
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
                              }).FirstOrDefaultAsync();
            if (user != null && passwordProtector.Unprotect(user.Password) == password)
            {
                return user;
            }
            return null;
        }
    }
}
