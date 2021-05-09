using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleWebApi.Models;

namespace PeopleWebApi.Repository
{
    public interface IAdultRepository
    {
        Task<List<Adult>> GetAdultsAsync();
        Task<Adult> GetAdultByIdAsync(int id);
        Task AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int id);
        Task<Adult> UpdateAdultAsync(Adult updatedAdult);
    }
}