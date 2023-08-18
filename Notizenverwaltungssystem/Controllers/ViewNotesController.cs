using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.otherClasses;

namespace Notizenverwaltungssystem.Controllers{
    [Route("[controller]")]
    [ApiController]
    public class ViewNotesController : Controller{
        [HttpGet]
        public IActionResult Get(){
            string html = "";
            try{
            
            if (Settings.ActiveUserName == "" || Settings.ActiveUserName == null){
                html = System.IO.File.ReadAllText("web/login.html");
            }
            else{
                html = System.IO.File.ReadAllText("web/viewNotes.html");
            }
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            return Content(html, "text/html");
        }
    }
}
