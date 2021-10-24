using System;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
