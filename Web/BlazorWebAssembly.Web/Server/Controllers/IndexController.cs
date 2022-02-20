using BlazorWebAssembly.Data.Models.DemoModels;
using BlazorWebAssembly.Web.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Web.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {
        public IndexController()
        {

        }

        [HttpGet]
        public DemoViewModel Get()
        {
            return new DemoViewModel() { Name = "I`M NESHO NESHEV" };
        }
    }
}