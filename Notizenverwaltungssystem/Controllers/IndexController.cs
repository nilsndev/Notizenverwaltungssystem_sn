using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.otherClasses;

namespace Notizenverwaltungssystem.Controllers{
    [Route("[controller]")]
    [ApiController]
    public class IndexController : ControllerBase{
        [HttpGet]
        public IActionResult Get(){
            string html = "";
            string js = "";
            try{
            if(Settings.ActiveUserName == "" || Settings.ActiveUserName == null){
              
                html = System.IO.File.ReadAllText("web/login.html");

            }
            else{
                html = System.IO.File.ReadAllText("web/newHomePage.html");
        

                }
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            return Content(html,"text/html");
        }
    }
}
