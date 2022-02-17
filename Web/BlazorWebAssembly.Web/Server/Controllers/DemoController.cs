using BlazorWebAssembly.Data.Models.DemoModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Web.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        public DemoController()
        {

        }

        [HttpGet]
        public Demo Get()
        {
            return new Demo() { Name = "Pesho" };
        }
    }
}
