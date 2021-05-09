using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleWebApi.Models;
using PeopleWebApi.Persistence;

namespace PeopleWebApi.Repository
{
    public class AdultRepository : IAdultRepository
    {
        public async Task<List<Adult>> GetAdultsAsync()
        {
            using AdultDbContext dbContext = new AdultDbContext();
            return dbContext.Adults.Include(a => a.JobTitle).ToList();
        }

        public async Task<Adult> GetAdultByIdAsync(int id)
        {
            using AdultDbContext dbContext = new AdultDbContext();
            return dbContext.Adults.Include(a => a.JobTitle).FirstOrDefault(a => a.Id == id);
        }

        public async Task AddAdultAsync(Adult adult)
        {
            using (AdultDbContext dbContext = new AdultDbContext())
            {
                Job job = await dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == adult.JobTitle.Id);
                adult.JobTitle = job;
                await dbContext.Adults.AddAsync(adult);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveAdultAsync(int id)
        {
            using (AdultDbContext dbContext = new AdultDbContext())
            {
                Adult adultToRemove = await GetAdultByIdAsync(id);
                dbContext.Adults.Remove(adultToRemove);
                dbContext.SaveChanges();
            }
        }

        public async Task<Adult> UpdateAdultAsync(Adult updatedAdult)
        {
            using (AdultDbContext dbContext = new AdultDbContext())
            {
                await RemoveAdultAsync(updatedAdult.Id);
                await AddAdultAsync(updatedAdult);
                dbContext.SaveChanges();
            }

            return updatedAdult;
        }
    }
}