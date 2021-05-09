using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleWebApi.Models;

namespace PeopleWebApi.Repository
{
    public interface IJobRepository
    {
        Task<List<Job>> GetJobsAsync();
    }
}