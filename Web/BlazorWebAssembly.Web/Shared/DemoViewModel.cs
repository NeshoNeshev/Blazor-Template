using BlazorWebAssembly.Services.Mapping.Interfaces;
using BlazorWebAssembly.Data.Models.DemoModels;

namespace BlazorWebAssembly.Web.Shared
{
    public class DemoViewModel : IMapFrom<Demo>
    {
        public string Name { get; set; }
    }
}