using BlazorWebAssembly.Data.Models.DemoModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Data.Seeding
{
    public class DemoSeed : ISeeder
    {
        public void Seed(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
           
            //dbContext.SaveChangesAsync();
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
        }
    }
}
