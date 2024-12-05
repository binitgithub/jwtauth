using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await appDbContext.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Username == username);

        }

        public async Task RegisterUserAsync(User user, string password)
        {
           user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
           appDbContext.Users.Add(user);
           await appDbContext.SaveChangesAsync();
        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            var user = await GetUserByUsernameAsync(username);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}