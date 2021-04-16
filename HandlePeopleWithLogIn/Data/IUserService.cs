using System.Threading.Tasks;
using HandlePeopleWithLogIn.Models;

namespace HandlePeopleWithLogIn.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
        Task AddUser(User user);
    }
}