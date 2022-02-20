using BlazaorWebAssembly.Services.Interfaces;
using BlazorWebAssembly.Data.Models.DemoModels;
using BlazorWebAssembly.Web.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Web.Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("[controller]")]
    public class DemoAdministrationController : ControllerBase
    {
        private readonly IDemoService demoService;

        public DemoAdministrationController(IDemoService demoService)
        {
            this.demoService = demoService;
        }
        [HttpGet]
        public DemoViewModel Get()
        {
            return this.demoService.GetDemo("FirstDemo");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string? name)
        {
            var demo = this.demoService.CreateDemo(name);
            if (demo != null)
            {
                return Ok(demo);
            }
            return BadRequest("Exist");
        }
    }
}
