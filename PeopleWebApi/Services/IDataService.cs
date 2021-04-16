using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleWebApi.Models;

namespace PeopleWebApi.Services
{
    public interface IDataService
    {
        Task<IList<Adult>> GetAdultAsync();
        Task RemoveAdultAsync(int id);
        Task<Adult> AddAdultAsync(Adult adult);
        Task<Adult> UpdateAdultAsync(Adult adult);
        Task<Adult> GetAdultsAsync(int id);
    }
}