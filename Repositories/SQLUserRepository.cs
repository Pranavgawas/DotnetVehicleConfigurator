﻿using demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle.Models;

namespace demo1.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        public SQLUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<User>> AddUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<ActionResult<bool>?> validateUser(User user)
        {
            var usernm = user.username;
            var passwd = user.password;
            var result = await context.Users.AnyAsync(u => u.username.Equals(usernm) && u.password.Equals(passwd));

            if (result)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> ValidateUser(User user)
        {
            var usernm = user.username;
            var passwd = user.password;
            var result = await context.Users.AnyAsync(u => u.username.Equals(usernm) && u.password.Equals(passwd));
            return result;
        }


    }
}
