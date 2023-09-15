using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.Models;
using Notizenverwaltungssystem.otherClasses;
using Notizenverwaltungssystem.Repositories;

namespace Notizenverwaltungssystem.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase{
        [HttpGet]
        public  IActionResult Get(){
            try{
            Note[] notes = NoteRepository.getNotesbyUserName();
            Console.WriteLine(notes[0].ID);
                return Ok(notes);
            }
            catch (Exception ex){ 
                Console.WriteLine(ex.Message); 
            }
            return BadRequest();
        }
        [HttpGet("GetNotesByFolderID")]
        public IActionResult GetNotesByFolderID(int folderID){
            try{
                Note[] notes = NoteRepository.getNotesbyUserNameFolderID(folderID);
                return Ok(notes);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post(Note note){
            try{
            bool success = NoteRepository.addOneNote(note);
            if (success){
                return Ok();
            }
            }catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id){
            try{
            bool success = NoteRepository.deleteOneNote(id);
            if (success){
                return Ok();
            }
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Put(Note updatedNote){
            try{
            
            bool success = NoteRepository.updateOne(updatedNote);
            if (success){
                return Ok();
            }
            }catch( Exception ex){
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
            
        }
    }
    
}
