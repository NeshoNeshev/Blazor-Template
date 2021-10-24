using BlazorWebAssembly.Data.Models.DemoModels;

namespace BlazaorWebAssembly.Services.Interfaces
{
    public interface IDemoService
    {
        Demo GetAll<T>(int? count = null);
    }
}
