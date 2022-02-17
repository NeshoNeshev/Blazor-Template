using BlazorWebAssembly.Data.Models.DemoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Web.Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("[controller]")]
    public class DemoAdministrationController : ControllerBase
    {
       
        public DemoAdministrationController()
        {

        }
        [HttpGet]
        public Demo Get()
        {
            return new Demo() { Name = "Administrator" };
        }

        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            var na = new Demo() { Name = name };
            if (na != null)
            {
                return Ok(na);
            }
            return BadRequest();
        }
    }
}
