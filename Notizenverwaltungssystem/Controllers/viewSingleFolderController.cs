using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.otherClasses;
using Notizenverwaltungssystem.Repositories;

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
        [HttpGet("GetByID")]
        public IActionResult GetByID(int id){
            string html = "";
            connection_class conn;
            try
            {
                if (Settings.ActiveUserName == "" || Settings.ActiveUserName == null)
                {
                    html = System.IO.File.ReadAllText("web/login");
                }
                else
                {
                    conn = connection_class.getInstance();
                    string query = $"SELECT folder_name FROM folder WHERE ID ={id}";
                    string folderName = conn.executeWithReturnValue<string>(query);
                    html = System.IO.File.ReadAllText("web/viewSingleFolder.html");
                    html = html.Replace("@id", id.ToString());
                    html = html.Replace("@folderName", folderName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Content(html, "text/html");
        }
    }
}
