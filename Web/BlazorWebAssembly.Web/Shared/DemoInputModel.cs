using System.ComponentModel.DataAnnotations;

namespace BlazorWebAssembly.Web.Shared
{
    public class DemoInputModel
    {
        [Required]
        public string? Name { get; set; }
    }
}
