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
        [HttpPost]
        public IActionResult Post(Folder folder){
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
