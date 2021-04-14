using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleWebApi.Models;
using PeopleWebApi.Persistence;

namespace PeopleWebApi.Data
{
    public class DataService : IDataService
    {
        private IList<Adult> adults;
        private FileContext FileContext;

        public DataService()
        {
            FileContext = new FileContext();
            adults = FileContext.Adults;
        }
        public async Task<IList<Adult>> GetAdultAsync()
        {
            return adults;
        }

        public async Task RemoveAdultAsync(int Id)
        {
            Adult toRemove = adults.First(t => t.Id == Id);
            adults.Remove(toRemove);
            FileContext.SaveChanges();
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            FileContext.SaveChanges();
            Console.WriteLine("New adult added: " + adult.Id);
            return adult;
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            Adult toWrite = new Adult
            {
                JobTitle = new Job(),
                Id = adult.Id == 0 ? toUpdate.Id : adult.Id,
                FirstName = adult.FirstName.Equals("") ? toUpdate.FirstName : adult.FirstName,
                LastName = adult.LastName.Equals("") ? toUpdate.LastName : adult.LastName
            };

            toWrite.JobTitle.JobTitle = adult.JobTitle.JobTitle.Equals("") ? toUpdate.JobTitle.JobTitle : adult.JobTitle.JobTitle;

            toWrite.JobTitle.Salary = adult.JobTitle.Salary == 0 ? toUpdate.JobTitle.Salary : adult.JobTitle.Salary;
            
            toWrite.Age = adult.Age == 0 ? toUpdate.Age : adult.Age;
            
            toWrite.Height = adult.Height == 0 ? toUpdate.Height : adult.Height;
            
            toWrite.Weight = adult.Weight == 0 ? toUpdate.Weight : adult.Weight;
            
            toWrite.EyeColor = adult.EyeColor.Equals("") ? toUpdate.EyeColor : adult.EyeColor;
            
            toWrite.HairColor = adult.HairColor.Equals("") ? toUpdate.HairColor : adult.HairColor;
            
            toWrite.Sex = adult.Sex.Equals("") ? toUpdate.Sex : adult.Sex;
            
            adults.Remove(adults.First(t => t.Id == adult.Id));
            adults.Add(toWrite);
            FileContext.UpdateList(adults);
            FileContext.SaveChanges();
            return adult;
        }
        
        public async Task<Adult> GetAsync(int Id)
        {
            return adults.First(t => t.Id == Id);
        }
    }
}