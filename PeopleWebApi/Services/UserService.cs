using System;
using System.Collections.Generic;
using System.Linq;
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

        public User ValidateUser(string userName, string password)
        {
            var user = users.First(u => u.UserName.Equals(userName));
            if (user == null) throw new Exception("User does not exist!");
            if (!user.Password.Equals(password)) throw new Exception("Incorrect password!");
            return user;
        }

        public void AddUser(User user)
        {
            User? first = null;
            try
            {
                first = users.First(u => u.UserName.Equals(user.UserName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (first != null)
            {
                throw new Exception("Username is taken!");
            }

            int max = users.Max(u => u.Id);
            user.Id = (++max);
            users.Add(user);
            fileContext.SaveChanges();
        }
        
        public void UpdateUser(User user)
        {
            User toUpdate = users.First(u => u.Id == user.Id);
            toUpdate.Password = user.Password;
            toUpdate.UserName = user.UserName;
            fileContext.SaveChanges();
        }

        public void RemoveUser(int userId)
        {
            User ToRemove = users.First(u => u.Id == userId);
            users.Remove(ToRemove);
            fileContext.SaveChanges();
        }
    }
}