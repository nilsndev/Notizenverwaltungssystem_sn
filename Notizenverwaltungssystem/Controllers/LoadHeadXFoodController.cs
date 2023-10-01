using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Notizenverwaltungssystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoadHeadXFoodController : ControllerBase{
        [HttpGet]
        public IActionResult Get(){
            string path = System.IO.File.ReadAllText("web/js/loadHeadXFood.js");
            return Content(path);
        }
    }
}
