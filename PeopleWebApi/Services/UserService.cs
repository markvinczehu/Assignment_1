using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleWebApi.Models;
using PeopleWebApi.Persistence;

namespace PeopleWebApi.Services
{
    public class UserService : IUserService
    {
        private IList<User> users;
        private FileContext fileContext;

        public UserService()
        {
            fileContext = new FileContext();
            users = fileContext.Users;
        }
        public async Task<IList<User>> GetUsersAsync()
        {
            return users;
        }
        
        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            User user = users.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");
        }

        public async Task<User> AddUserAsync(User user)
        {
            users.Add(user);
            fileContext.SaveChanges();
            return user;
        }
    }
}