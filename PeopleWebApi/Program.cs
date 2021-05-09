using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PeopleWebApi.Models;
using PeopleWebApi.Persistence;

namespace PeopleWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            
            using (AdultDbContext adbc = new AdultDbContext())
            {
                if (!adbc.Adults.Any())
                {
                    Seed(adbc);
                }
            }
        }
        
        private static void Seed(AdultDbContext adbc)
        {
            FileContext fileContext = new FileContext();
            IList<Adult> adults = new List<Adult>();
            adults = fileContext.Adults;

            adbc.Add(adults);
            
            adbc.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}