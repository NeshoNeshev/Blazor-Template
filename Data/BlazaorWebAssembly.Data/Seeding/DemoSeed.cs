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
            if (dbContext.Demos.Any())
            {
                return;
            }

            var demo = new Demo
            {
                Name = "Demo",
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = null,
                IsDeleted = false,
                DeletedOn = null,
            };
            dbContext.Demos.AddAsync(demo);
            //dbContext.SaveChangesAsync();
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Demos.Any())
            {
                return;
            }

            var demo = new Demo
            {
                Name = "Demo",
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = null,
                IsDeleted = false,
                DeletedOn = null,
            };
            await dbContext.Demos.AddAsync(demo);
        }
    }
}
