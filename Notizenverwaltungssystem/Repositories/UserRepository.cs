using Notizenverwaltungssystem.otherClasses;
using MySql.Data.MySqlClient;
using Notizenverwaltungssystem.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Collections;
using Org.BouncyCastle.Asn1.BC;

namespace Notizenverwaltungssystem.Repositories{
    public static class UserRepository{
        #region Methods
        public static bool GetOneUser(User user){
            connection_class conn_instance = connection_class.getInstance();
            string salt = GetSalt(user, conn_instance);
            string pwHash = GetHashPW(user, conn_instance);
            string query = "SELECT * FROM user WHERE userName = @userName AND passwordHash = @pwHash";
            var parameters = new Hashtable{
                { "@userName", user.UserName },
                { "@pwHash", pwHash }
            };
            bool pwCorrect = Hashing.VertifyPassword(user.User_pass, pwHash, salt);
            bool success = conn_instance.executeSELECTQueryWParams(query, parameters);

            if (success && pwCorrect)
            {
                Settings.ActiveUserName = user.UserName;
            }

            return success;
        }

        public static string GetSalt(User user, connection_class conn_instance){
            string query = "SELECT salt FROM user WHERE userName = @userName";
            var parameters = new Hashtable{
                { "@userName", user.UserName }
            };
            string salt = conn_instance.executeWithReturnValueParams<string>(query, parameters);
            return salt;
        }

        public static string GetHashPW(User user, connection_class conn_instance){
            string query = "SELECT passwordHash FROM user WHERE userName = @userName";
            var parameters = new Hashtable{
                { "@userName", user.UserName }
            };
            string pwHash = conn_instance.executeWithReturnValueParams<string>(query, parameters);
            return pwHash;
        }
        public static bool AddUser(User user){
            connection_class conn_instance = connection_class.getInstance();
            MySqlCommand cmd = new MySqlCommand();
            var parameters = new Hashtable();
            parameters.Add("@userName", user.UserName);
            string hashedPW = Hashing.HashPassword(user.User_pass);
            string salt = Hashing.Salt;
            parameters.Add("@userPass", hashedPW);
            parameters.Add("@salt", salt);
            string query = "INSERT INTO user(userName, passwordHash, salt) " +
                           "VALUES(@userName, @userPass, @salt)";
            int rowsAffected = conn_instance.executeQueryWithParams(query, parameters);
            if (rowsAffected > 0){
                Settings.ActiveUserName = user.UserName;
                return true;
            }
            return false;
        }

        public static async void sendMail(string mail){
            EmailSender sender = new EmailSender();
            int otp = generateOTP();
            await sender.SendEmailAsync(mail,
                                        "Authentication Code",
                                        otp.ToString());
            Settings.ActiveOTP = otp;
        }
        public static int generateOTP(){
            Random rand = new Random();
            int otp = rand.Next(1000, 9000);
            return otp;
        }
        #endregion

    }
}
