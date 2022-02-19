using BlazorWebAssembly.Data.Models.DemoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Data.Seeding
{
    public static class DemoSeed 
    {
        public static void SeedDemos(ApplicationDbContext dbContext)
        {

            var demos = new List<Demo>() { new Demo { Name = "FirstDemo" }, new Demo { Name = "SecondDemo"} };
            if (dbContext.Demos.Any())
            {
                return;
            }
            dbContext.Demos.AddRange(demos);
            dbContext.SaveChanges();
        }
    }
}
