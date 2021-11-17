using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace App
{
    public class Program
    {
        public static void Main()
        {
            string connectionString = GetConnectionString();

            bool useConsoleLogger = true; // IHostingEnvironment.IsDevelopment

            using (var context = new SchoolContext(connectionString, useConsoleLogger))
            {
                //Student student = context.Students.Find(1L);

                Student student = context.Students
                    .Include(x => x.FavoriteCourse)
                    .SingleOrDefault(x => x.Id == 1);

                if (student != null) System.Console.WriteLine($"Student found: {student.Email}");
            }
        }

        private static string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration["ConnectionString"];
        }
    }
}
