using PeopleWebApi.Models;

namespace PeopleWebApi.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
        void AddUser(User user);
    }
}