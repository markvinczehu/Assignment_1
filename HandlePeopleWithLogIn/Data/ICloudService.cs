using System.Collections.Generic;
using System.Threading.Tasks;
using HandlePeopleWithLogIn.Models;

namespace HandlePeopleWithLogIn.Data
{
    public interface ICloudService
    {
        Task<IList<Adult>> GetAdultAsync();
        Task<Adult> AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int Id);
        Task<Adult> UpdateAdultAsync(Adult adult);
        Task<Adult> GetAsync(int Id);
    }
}