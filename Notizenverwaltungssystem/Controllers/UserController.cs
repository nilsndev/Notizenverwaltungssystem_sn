using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.Models;
using MySql.Data.MySqlClient;
using Notizenverwaltungssystem.otherClasses;
using Notizenverwaltungssystem.Repositories;

namespace Notizenverwaltungssystem.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        [HttpPost]
        public IActionResult Post(User user){
            try{

            
            bool success = UserRepository.addUser(user);
            if (success){
                return Ok();
            }
            }catch(Exception ex){
                Console.WriteLine("Fehler Nachricht: " +ex.Message);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Get(string UserName, string User_pass){
            try{
            bool success = UserRepository.getOneUser(new User(UserName,User_pass));
            if (success){
                return Ok();
            }
            }catch(Exception ex){
                Console.WriteLine("Fehler Nachricht: " +ex.Message);
            }
            return BadRequest();
        }


    }
}
