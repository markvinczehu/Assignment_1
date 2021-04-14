using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleWebApi.Models;

namespace PeopleWebApi.Data
{
    public interface IDataService
    {
        Task<IList<Adult>> GetAdultAsync();
        Task RemoveAdultAsync(int id);
        Task<Adult> AddAdultAsync(Adult adult);
        Task<Adult> UpdateAdultAsync(Adult adult);
        Task<Adult> GetAsync(int id);
    }
}