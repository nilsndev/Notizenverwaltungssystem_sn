

namespace Notizenverwaltungssystem.otherClasses
{
    public static class Hashing{
        #region Fields
        static string _salt;
        static string _hashedPassword;

        #endregion
        #region Characteristics
        public static string Salt { get { return _salt; } }
        public static string HashPW { get { return _hashedPassword; } }
        #endregion
        #region Methods

        public static string HashPassword(string password){
            _salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            _hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, _salt);
            return _hashedPassword;
        }
        public static bool VertifyPassword(string enteredPassword, string storedHash, string salt){
            string hashedEnteredPassword = BCrypt.Net.BCrypt.HashPassword(enteredPassword, salt);
            _hashedPassword = hashedEnteredPassword;
            return storedHash == hashedEnteredPassword;
        }
        #endregion

    }
}
