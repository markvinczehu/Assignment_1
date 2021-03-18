using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;
using Persistence;

namespace HandlePeopleWithLogIn.Data
{
    public class DataService : IDataService
    {
        // private string adultFile = "adults.json";
        private IList<Adult> adults;
        private FileContext FileContext;

        public DataService()
        {
            FileContext = new FileContext();
            adults = FileContext.Adults;
            // if (!File.Exists(adultFile))
            // {
            //     WriteAdultsFile();
            // }
            // else
            // {
            //     string content = File.ReadAllText(adultFile);
            //     adults = JsonSerializer.Deserialize<List<Adult>>(content);
            // }
        }
        public IList<Adult> GetAdults()
        {
            return adults;
        }

        public void AddAdult(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            FileContext.SaveChanges();
        }

        public void RemoveAdult(int Id)
        {
            Adult toRemove = adults.First(t => t.Id == Id);
            adults.Remove(toRemove);
            FileContext.SaveChanges();
        }

        public void Update(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.Age = adult.Age;
            toUpdate.Height = adult.Height;
            toUpdate.Weight = adult.Weight;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.Sex = adult.Sex;
        }

        public Adult Get(int Id)
        {
            return adults.First(t => t.Id == Id);
        }

        // private void WriteAdultsFile()
        // {
        //     string adultsAsJson = JsonSerializer.Serialize(adults);
        //     File.WriteAllText(adultFile, adultsAsJson);
        // }
    }
}