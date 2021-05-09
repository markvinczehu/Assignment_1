using PeopleWebApi.Models;

namespace PeopleWebApi.Services
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
        void AddUser(User user);
        void UpdateUser(User user);
        void RemoveUser(int userId);
    }
}