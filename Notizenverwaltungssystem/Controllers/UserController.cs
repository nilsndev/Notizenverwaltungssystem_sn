using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notizenverwaltungssystem.Models;
using MySql.Data.MySqlClient;
using Notizenverwaltungssystem.otherClasses;
using Notizenverwaltungssystem.Repositories;
using Notizenverwaltungssystem.interfaces;
using System.Text.Encodings.Web;

namespace Notizenverwaltungssystem.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IEmailSender _emailSender;
        public UserController(IEmailSender emailSender){
            _emailSender = emailSender;
        }
        [HttpPost]
        public IActionResult Post(User user){
            try{
                if(user.OTP == Settings.ActiveOTP){ 
                    bool success = UserRepository.AddUser(user);
                    if (success){
                        return Ok();
                    }
                }
            }
            catch(Exception ex){
                Console.WriteLine("Fehler Nachricht: " +ex.Message);
            }
            return BadRequest();
        }
        [HttpPost("SendMail")]
        public IActionResult SendMail(User user){
            try{
                UserRepository.sendMail(user.Email);
                return Ok();
            }
            catch (Exception ex){
                Console.WriteLine("Fehler Nachricht: " + ex.Message);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Get(string UserName, string User_pass){
            try{

            bool success = UserRepository.GetOneUser(new User(UserName,User_pass));
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
