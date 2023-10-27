using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Notizenverwaltungssystem.Models{
    public class User{
        #region Constructors
        public User(string userName, string user_pass){
            _userName = userName;
            _user_pass = user_pass;
        }
        #endregion
        #region Fields
        [Required] string _userName;
        [Required] string _user_pass;
        int _otp;
        string _email;
        #endregion
        #region Characteristics
        [JsonPropertyName("UserName")]
        public string UserName { get { return _userName; } set { _userName = value; } }
        [JsonPropertyName("User_pass")]
        public string User_pass { get { return _user_pass; } set { _user_pass = value; } }
        [JsonPropertyName("mail")]
        public string Email { get {return _email;} set { _email = value; } }
        [JsonPropertyName("otp")]
        public  int OTP { get { return _otp; } set { _otp = value; } }
        #endregion
        #region Methods
        #endregion
    }
}
