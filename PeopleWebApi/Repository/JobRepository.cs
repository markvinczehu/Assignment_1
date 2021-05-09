using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleWebApi.Models;
using PeopleWebApi.Persistence;

namespace PeopleWebApi.Repository
{
    public class JobRepository : IJobRepository
    {
        public async Task<List<Job>> GetJobsAsync()
        {
            using AdultDbContext dbContext = new AdultDbContext();
            return dbContext.Jobs.ToList();
        }
    }
}