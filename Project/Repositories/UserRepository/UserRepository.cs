using Microsoft.AspNetCore.Identity;
using Project.Models;

namespace Project.Repositories.UserRepository
{
    public class UserRepository: IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User>? GetUserById(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }
        public async Task<User>? GetByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task CreateAsync(User user)
        {
            var newUser = await _userManager.CreateAsync(user);
            if (newUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return;
            }
        }

        public async Task Update(User user)
        {
            user.SecurityStamp = Guid.NewGuid().ToString();
            await _userManager.UpdateAsync(user);
        }

        public async Task Delete(Guid id)
        {
            var userFound = await GetUserById(id);

            await _userManager.DeleteAsync(userFound);
        }
    }
}
