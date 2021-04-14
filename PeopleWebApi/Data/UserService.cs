using System;
using System.Collections.Generic;
using System.Linq;
using PeopleWebApi.Models;
using PeopleWebApi.Persistence;

namespace PeopleWebApi.Data
{
    public class UserService : IUserService {
        private IList<User> users;
        private FileContext FileContext;
        public UserService()
        {
            FileContext = new FileContext();
            users = FileContext.Users;
        }

        public User ValidateUser(string userName, string password) {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null) {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password)) {
                throw new Exception("Incorrect password");
            }

            return first;
        }

        public void AddUser(User user)
        {
            users.Add(user);
            FileContext.SaveChanges();
        }
    }
}