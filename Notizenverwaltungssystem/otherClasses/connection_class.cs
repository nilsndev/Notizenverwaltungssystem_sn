using MySql.Data.MySqlClient;
using System.Collections;
using System.Data.Common;
using System.Collections.Generic;

namespace Notizenverwaltungssystem.otherClasses
{
    public class connection_class{
        #region Constructors
        private connection_class(){
            string connectionString = $"server={_host};userid={_userID};password={_passWord};database={_database};";
            _connection = new MySqlConnection(connectionString);
        }
        #endregion
        #region Fields
        string _host = "localhost";
        string _userID = "root";
        string _passWord = "Lolkopf13";
        string _database = "notizenverwaltungssystem_db";
        static connection_class _instance;
        MySqlConnection _connection;
        #endregion
        #region Charctersitics
        public string Host { get { return _host; } }
        public string UserID { get { return _userID; } }
        public string Password { get { return _passWord; } }
        public string Database { get { return _database; } }

        #endregion
        #region Methods
        public static connection_class getInstance(){
            if(_instance == null){
                _instance = new connection_class();
            }
            return _instance;

        }
        public MySqlConnection getConnection(){
            if(_connection.State != System.Data.ConnectionState.Open){
                _connection.Open();
            }
            return _connection;

        }
        public void closeConnection(){
            if(_connection.State != System.Data.ConnectionState.Closed){ 
                _connection.Close(); 
            }

        }
        public bool executeSELECTQuery(string query){
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            DbDataReader reader = cmd.ExecuteReader();
            bool success = reader.HasRows;
            reader.Close();
            return success;
        }
        public bool executeSELECTQueryWParams(string query,Hashtable hashTable){
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            foreach (DictionaryEntry hash in hashTable){
                cmd.Parameters.AddWithValue(hash.Key.ToString(), hash.Value);
            }
            DbDataReader reader = cmd.ExecuteReader();
            bool success = reader.HasRows;
            reader.Close();
            return success;
        }
        public T[] ReturnValuesFromQuery<T>(string query, Func<MySqlDataReader, T> mapFunction){
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            List<T> results = new List<T>();
            using (MySqlDataReader reader = cmd.ExecuteReader()){
                while (reader.Read()){
                    T item = mapFunction(reader);
                    results.Add(item);
                }
            }
            return results.ToArray();
        }
        public T[] ReturnValuesFromParameterizedQuery<T>(string query, Dictionary<string, object> parameters, Func<MySqlDataReader, T> mapFunction){
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            foreach (var parameter in parameters){
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }
            List<T> results = new List<T>();
            using (MySqlDataReader reader = cmd.ExecuteReader()){
                while (reader.Read()){
                    T item = mapFunction(reader);
                    results.Add(item);
                }
            }
            return results.ToArray();
        }
        public T executeWithReturnValue<T>(string query){
            T returnValue;
            MySqlCommand cmd = new MySqlCommand(query,getConnection());
            returnValue = (T)cmd.ExecuteScalar();
            return returnValue; 
        }
        public T executeWithReturnValueParams<T>(string query,Hashtable hashTable){
            T returnValue;
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            foreach (DictionaryEntry hash in hashTable){
                cmd.Parameters.AddWithValue(hash.Key.ToString(), hash.Value);
            }
            returnValue = (T)cmd.ExecuteScalar();
            return returnValue;
        }
        public int executeQuery(string query){
            MySqlCommand cmd = new MySqlCommand(query,getConnection());
            int rowsAffected =cmd.ExecuteNonQuery();
            cmd.Dispose();
            return rowsAffected;
        }
        public int executeQueryWithParams(string query,Hashtable hashTable){
            MySqlCommand cmd = new MySqlCommand(query,getConnection());
            foreach(DictionaryEntry hash in hashTable){
                cmd.Parameters.AddWithValue(hash.Key.ToString(), hash.Value);
            }
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }
        public bool checkRowsAffected(int rowsAffected){
            if (rowsAffected > 0){
                return true;
            }
            return false;
        }
        #endregion
    }
}
