using BlazaorWebAssembly.Services.Interfaces;
using BlazorWebAssembly.Services.Mapping;
using BlazorWebAssembly.Data;
using BlazorWebAssembly.Data.Models.DemoModels;
using System.Linq;
using BlazorWebAssembly.Web.Shared;
using System;

namespace BlazaorWebAssembly.Services
{
    public class DemoService : IDemoService
    {
        private readonly ApplicationDbContext dbContext;

        public DemoService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //private readonly IDeletableRepository<Demo> demoRepository;

        //public DemoService(IDeletableRepository<Demo> demoRepository)
        //{
        //    this.demoRepository = demoRepository;
        //}

        //public Demo GetAll<T>(int? count = null)
        //{
        //    IQueryable<Demo> query = this.demoRepository.All().OrderBy(x => x.Name);
        //    if (count.HasValue)
        //    {
        //        query = query.Take(count.Value);
        //    }

        //    return query.First();
        //}
        public int GetCount()
        {
            return this.dbContext.Demos.Count();
        }

        public DemoViewModel GetDemo(string name)
        {
            var demo = this.dbContext.Demos.Where(x => x.Name == name).To<DemoViewModel>().First();


            return demo;
        }
        public string CreateDemo(string name)
        {
            var existingDemo = this.dbContext.Demos.Any(d => d.Name == name);

            if (existingDemo)
            {
                throw new ArgumentException("Demo exist");
            }
            else
            {
                var demo = new Demo();
                demo.Name = name;

                this.dbContext.Demos.Add(demo);
                this.dbContext.SaveChanges();

                return name;
            }
        }
    }
}
