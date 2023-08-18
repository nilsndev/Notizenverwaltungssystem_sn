using System.ComponentModel.DataAnnotations;

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
        #endregion
        #region Characteristics
        public string UserName { get { return _userName; } set { _userName = value; } }
        public string User_pass { get { return _user_pass; } set { _user_pass = value; } }
        #endregion
        #region Methods
        #endregion
    }
}
