using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

namespace HandlePeopleWithLogIn.Data
{
    public class TodoJSONData : IAdultService
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public TodoJSONData()
        {
            if (!File.Exists(adultFile))
            {
                // Seed();
                WriteTodosFile();
            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }
        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        public void AddAdult(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteTodosFile();
        }

        public void RemoveAdult(int Id)
        {
            Adult toRemove = adults.First(t => t.Id == Id);
            adults.Remove(toRemove);
            WriteTodosFile();
        }

        public void Update(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            // toUpdate.IsCompleted = todo.IsCompleted;
            // toUpdate.Title = todo.Title;
            WriteTodosFile();
        }

        public Adult Get(int id)
        {
            return adults.First(t => t.Id == id);
        }

        private void WriteTodosFile()
        {
            string adultsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, adultsAsJson);
        }

        // private void Seed()
        // {
        //     Todo[] ts =
        //     {
        //         new Todo
        //         {
        //             UserId = 1,
        //             TodoId = 1,
        //             Title = "Do Dishes",
        //             IsCompleted = false
        //         },
        //         new Todo
        //         {
        //             UserId = 1,
        //             TodoId = 2,
        //             Title = "Walk the dog",
        //             IsCompleted = false
        //         },
        //         new Todo
        //         {
        //             UserId = 2,
        //             TodoId = 3,
        //             Title = "Do DNP homework",
        //             IsCompleted = true
        //         },
        //         new Todo
        //         {
        //             UserId = 3,
        //             TodoId = 4,
        //             Title = "Eat breakfast",
        //             IsCompleted = false
        //         },
        //         new Todo
        //         {
        //             UserId = 4,
        //             TodoId = 5,
        //             Title = "Mow lawn",
        //             IsCompleted = true
        //         },
        //     };
        //     todos = ts.ToList();
        // }
    }
}