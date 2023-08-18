using Microsoft.AspNetCore.Mvc;

namespace Notizenverwaltungssystem.Controllers{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase{
        [HttpGet]
        public IActionResult Get(){
            string html = "";
            try
            {
            
            html = System.IO.File.ReadAllText("web/login.html");
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            return Content(html, "text/html");
        }
    }
}
