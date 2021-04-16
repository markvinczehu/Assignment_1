using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleWebApi.Models;

namespace PeopleWebApi.Services
{
    public interface IUserService
    {
        Task<IList<User>> GetUsersAsync();
        Task<User> ValidateUserAsync(string userName, string password);
        Task<User> AddUserAsync(User user);
    }
}