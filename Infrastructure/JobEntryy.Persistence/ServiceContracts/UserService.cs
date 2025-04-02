using JobEntryy.Application.Abstracts.ServiceContracts;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Exceptions;
using JobEntryy.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace JobEntryy.Persistence.ServiceContracts
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            UserDto? user = await userManager.Users.Where(x => x.UserType == Domain.Enums.UserType.Admin).OrderByDescending(x => x.Created).
            Select(x => new UserDto { Id = x.Id, Name = x.Name, UserName = x.UserName, Email = x.Email, Created = x.Created, Status = x.Status }).
            FirstOrDefaultAsync(x=>x.Id==id) ?? throw new UserNotFoundException();

            var roles = await userManager.GetRolesAsync(await userManager.FindByIdAsync(user.Id.ToString()));
            user.Roles = roles.ToArray();

            return user;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var users = await userManager.Users.Where(x=>x.UserType==Domain.Enums.UserType.Admin).OrderByDescending(x => x.Created).
            Select(x => new UserDto{ Id = x.Id, Name = x.Name, UserName = x.UserName, Email = x.Email, Created = x.Created, Status = x.Status}).ToListAsync();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(await userManager.FindByIdAsync(user.Id.ToString()));
                user.Roles = roles.ToArray();
            }

            return users;
        }
    }
}
