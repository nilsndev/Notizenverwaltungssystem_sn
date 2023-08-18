using Notizenverwaltungssystem.otherClasses;
using MySql.Data.MySqlClient;
using Notizenverwaltungssystem.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Collections;

namespace Notizenverwaltungssystem.Repositories{
    public static class UserRepository{
        #region Methods
        public static bool getOneUser(User user){
            connection_class conn_instance = connection_class.getInstance();
            string salt = getSalt(user,conn_instance);
            string pwHash = getHashPW(user,conn_instance);
            string query = $"SELECT * FROM user WHERE userName = '{user.UserName}' AND passwordHash = '{pwHash}'";
            bool pwCorrect = Hashing.VertifyPassword(user.User_pass, pwHash, salt);
            bool success = conn_instance.executeSELECTQuery(query);
            if (success && pwCorrect){
                Settings.ActiveUserName = user.UserName;
            }
            return success;
        }
        public static string getSalt(User user, connection_class conn_instance){
            string query = $"SELECT salt FROM user WHERE userName = '{user.UserName}'";
            string salt = conn_instance.executeWithReturnValue<string>(query);
            return salt;
        }
        public static string getHashPW(User user, connection_class conn_instance){
            string query = $"SELECT passwordHash FROM user WHERE userName = '{user.UserName}'";
            string pwHash = conn_instance.executeWithReturnValue<string>(query);
            return pwHash;
        }
        public static bool addUser(User user){
            connection_class conn_instance = connection_class.getInstance();
            MySqlCommand cmd = new MySqlCommand();
            Hashtable hashTable = new Hashtable();
            hashTable.Add("@userName", user.UserName);
            string hashedPW = Hashing.HashPassword(user.User_pass);
            string salt = Hashing.Salt;
            hashTable.Add("@userPass", hashedPW);
            hashTable.Add("@salt", salt);
            
            string query = "INSERT INTO user(userName,passwordHash,salt) " +
                           "VALUES(@userName,@userPass,@salt)";
            int rowsAffected = conn_instance.executeQueryWithParams(query,hashTable);
            if(rowsAffected > 0){
                return true;
            }
            return false;

        }
        #endregion

    }
}
