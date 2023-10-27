using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.Models;
using Notizenverwaltungssystem.otherClasses;
using Notizenverwaltungssystem.Repositories;

namespace Notizenverwaltungssystem.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase{
        [HttpGet]
        public IActionResult Get(){
            try{
                Folder[] folders = FolderRepository.GetFoldersByUserName();
                Console.WriteLine(folders[0].ID);
                return Ok(folders);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }
        [HttpGet("GetChildFoldersByID")]
        public IActionResult GetChildFoldersByID(int id){
            try
            {
                Folder[] childFolders = FolderRepository.GetFoldersByUserNameAndPFID(id);
                return Ok(childFolders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet("GetFolderByID")]
        public IActionResult GetFolderByID(int id){
            Folder fold = new Folder();
            fold.ID = id;
            try{
                string query = "SELECT folder_name from folder WHERE ID = " + id;
                connection_class conn = connection_class.getInstance();
                fold.FolderName = conn.executeWithReturnValue<string>(query);
                return Ok( fold );
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Post(Folder folder){
            folder = Encoding.EncodeObject(folder);
            bool success =FolderRepository.AddFolder(folder);
            if (success){
                return Ok();
            }
            else{
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Put(Folder folder){
            folder = Encoding.EncodeObject(folder);
            Console.WriteLine(folder.FolderName);
            bool success = FolderRepository.updateOne(folder);
            if (success){
                return Ok();
            }
            else{
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            if (FolderRepository.deleteOneFolder(id)){
                return Ok();
            }
            else{
                return BadRequest();
            }
        }
    }
}
