using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.otherClasses;

namespace Notizenverwaltungssystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddFolderController : ControllerBase{
        [HttpGet]
        public IActionResult Get()
        {
            string html = "";
            try
            {


                if (Settings.ActiveUserName == "" || Settings.ActiveUserName == null)
                {
                    html = System.IO.File.ReadAllText("web/login.html");

                }
                else
                {
                    html = System.IO.File.ReadAllText("web/addFolder.html");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return Content(html, "text/html");
        }
    }
}

