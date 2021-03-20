using Models;

namespace HandlePeopleWithLogIn.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
        void AddUser(User user);
    }
}