using BlazorWebAssembly.Data.Models.DeletableModels;

namespace BlazorWebAssembly.Data.Models.DemoModels
{
    public class Demo : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
