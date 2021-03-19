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
            Adult toWrite = new Adult();
            toWrite.JobTitle = new Job();

            if (adult.FirstName.Equals(""))
            {
                toWrite.FirstName = toUpdate.FirstName;
            }
            else
            {
                toWrite.FirstName = adult.FirstName;
            }
            if (adult.LastName.Equals(""))
            {
                toWrite.LastName = toUpdate.LastName;
            }
            else
            {
                toWrite.LastName = adult.LastName;
            }
            if (adult.JobTitle.JobTitle.Equals(""))
            {
                toWrite.JobTitle.JobTitle = toUpdate.JobTitle.JobTitle;
            }
            else
            {
                toWrite.JobTitle.JobTitle = adult.JobTitle.JobTitle;
            }
            if (adult.Age == 0)
            {
                toWrite.Age = toUpdate.Age;
            }
            else
            {
                toWrite.Age = adult.Age;
            }
            if (adult.Height == 0)
            {
                toWrite.Height = toUpdate.Height;
            }
            else
            {
                toWrite.Height = adult.Height;
            }
            if (adult.Weight == 0)
            {
                toWrite.Weight = toUpdate.Weight;
            }
            else
            {
                toWrite.Weight = adult.Weight;
            }
            if (adult.EyeColor.Equals(""))
            {
                toWrite.EyeColor = toUpdate.EyeColor;
            }
            else
            {
                toWrite.EyeColor = adult.EyeColor;
            }
            if (adult.HairColor.Equals(""))
            {
                toWrite.HairColor = toUpdate.HairColor;
            }
            else
            {
                toWrite.HairColor = adult.HairColor;
            }
            if (adult.Sex.Equals(""))
            {
                toWrite.Sex = toUpdate.Sex;
            }
            else
            {
                toWrite.Sex = adult.Sex;
            }
            
            adults.Remove(adults.First(t => t.Id == adult.Id));
            adults.Add(toWrite);
            FileContext.UpdateList(adults);
            FileContext.SaveChanges();
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