using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Notizenverwaltungssystem.Controllers{
    [Route("[controller]")]
    [ApiController]
    public class FooterController : ControllerBase{
        [HttpGet]
        public IActionResult Get(){
            string html = "";
            try
            {

                html = System.IO.File.ReadAllText("web/footer.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Content(html, "text/html");
        }
    }
}
