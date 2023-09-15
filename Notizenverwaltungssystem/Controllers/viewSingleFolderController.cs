using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.otherClasses;

namespace Notizenverwaltungssystem.Controllers{
    [Route("[controller]")]
    [ApiController]
    public class viewSingleFolderController : ControllerBase{
        [HttpGet]
        public IActionResult Get(int id, string folderName){
            string html = "";
            try{
                if (Settings.ActiveUserName == "" || Settings.ActiveUserName == null){
                    html = System.IO.File.ReadAllText("web/login");
                }
                else{
                    html = System.IO.File.ReadAllText("web/viewSingleFolder.html");
                    html = html.Replace("@id", id.ToString());
                    html = html.Replace("@folderName", folderName);
                }
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
            return Content(html, "text/html");
        }
    }
}
