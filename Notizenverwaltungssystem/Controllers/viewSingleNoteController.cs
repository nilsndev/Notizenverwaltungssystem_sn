using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.otherClasses;

namespace Notizenverwaltungssystem.Controllers{
    [Route("[controller]")]
    [ApiController]
    public class viewSingleNoteController : ControllerBase{
        [HttpGet]
        public IActionResult Get(int id,string title,string? note_text, int? foldID){
            string html = "";
            try{
            
            if (Settings.ActiveUserName == "" || Settings.ActiveUserName == null){
                html = System.IO.File.ReadAllText("web/login.html");
            }
            else{
                html = System.IO.File.ReadAllText("web/viewSingleNote.html");
                html = html.Replace("@id", id.ToString());
                html = html.Replace("@title", title);
                html = html.Replace("@noteText", note_text);
                html = html.Replace("@foldID", foldID.ToString());
                }
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            return Content(html, "text/html");
        }
    }
}
