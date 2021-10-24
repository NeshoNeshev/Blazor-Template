using BlazaorWebAssembly.Services.Interfaces;
using BlazorWebAssembly.Data.Models.DemoModels;
using System.Linq;

namespace BlazaorWebAssembly.Services
{
    public class DemoService : IDemoService
    {
        private readonly IDeletableRepository<Demo> demoRepository;

        public DemoService(IDeletableRepository<Demo> demoRepository)
        {
            this.demoRepository = demoRepository;
        }

        public Demo GetAll<T>(int? count = null)
        {
            IQueryable<Demo> query = this.demoRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.First();
        }
        public int GetCount()
        {
            return this.demoRepository.All().Count();
        }
    }
}
