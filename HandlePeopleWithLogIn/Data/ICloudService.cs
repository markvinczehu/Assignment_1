using System.Collections.Generic;
using System.Threading.Tasks;
using HandlePeopleWithLogIn.Models;

namespace HandlePeopleWithLogIn.Data
{
    public interface ICloudService
    {
        Task<List<Adult>> GetAdultAsync();
        Task AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int Id);
        Task UpdateAdultAsync(Adult adult);
        Task<Adult> GetAsync(int Id);
        Task<List<Job>> GetJobsAsync();
    }
}