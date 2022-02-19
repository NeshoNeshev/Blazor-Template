using BlazorWebAssembly.Web.Shared;

namespace BlazaorWebAssembly.Services.Interfaces
{
    public interface IDemoService
    {
        public int GetCount();

        public DemoViewModel GetDemo(string name);

        public string CreateDemo(string name);
    }
}