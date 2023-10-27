using Notizenverwaltungssystem.Models;
using Notizenverwaltungssystem.otherClasses;
using Org.BouncyCastle.Asn1.X509;
using System.Collections;

namespace Notizenverwaltungssystem.Repositories{
    public static class FolderRepository{
        #region Methods
        public static bool AddFolder(Folder folder) {
            connection_class conn = connection_class.getInstance();
            string query = "INSERT INTO folder (folder_name,userName,parent_folder_ID)"
                + $" VALUES(@folderName,@userName,@parent_folder_ID)";
            var parameters = new Hashtable{
                {"@folderName", folder.FolderName},
                {"@userName",Settings.ActiveUserName},
                {"@parent_folder_ID", folder.ParentFolderID ?? (object)DBNull.Value}
            };
            int rowsAffected = conn.executeQueryWithParams(query,parameters);
            return conn.checkRowsAffected(rowsAffected);
        }
        public static Folder[] GetFoldersByUserName(){
            connection_class conn = connection_class.getInstance();
            string query = $"SELECT * FROM folder WHERE userName = @userName AND parent_folder_ID IS NULL";
            var parameters = new Dictionary<string, object>{
                {"@userName", Settings.ActiveUserName}
            };
            Folder[] folders = conn.ReturnValuesFromParameterizedQuery(query,parameters ,reader => {
                return new Folder(
                    Convert.ToInt32(reader["ID"]),
                    folderName: reader["folder_name"].ToString(),
                    userName: reader["userName"].ToString()
                        );
            });
            return folders;
        }
        public static Folder[] GetFoldersByUserNameAndPFID(int id){
            connection_class conn = connection_class.getInstance();
            string query = $"SELECT * FROM folder WHERE userName = @userName AND parent_folder_ID = @parent_folder_ID";
            var parameters = new Dictionary<string, object>{
                {"@userName", Settings.ActiveUserName},
                {"@parent_folder_ID", id}
            };
            Folder[] folders = conn.ReturnValuesFromParameterizedQuery(query,parameters, reader => {
                return new Folder(
                    Convert.ToInt32(reader["ID"]),
                    folderName: reader["folder_name"].ToString(),
                    userName: reader["userName"].ToString()
                );
            });
            return folders;
        }
        public static bool updateOne(Folder updatedFolder){
            string query = $"UPDATE folder SET folder_name = @folderName, parent_folder_ID = @parent_folder_ID WHERE ID = @ID";
            var parameters = new Hashtable{
                {"@folderName", updatedFolder.FolderName },
                {"@parent_folder_ID", updatedFolder.ParentFolderID ?? (object)DBNull.Value},
                {"@ID", updatedFolder.ID }
            };
            connection_class conn = connection_class.getInstance();
            int rowsAffected = conn.executeQueryWithParams(query,parameters);
            return conn.checkRowsAffected(rowsAffected);
        }
        public static bool deleteOneFolder(int noteID){
            connection_class conn = connection_class.getInstance();
            string query = $"DELETE FROM folder WHERE (ID = @ID) ";
            var parameters = new Hashtable{
                {"@ID",noteID}
            };
            int rowsAffected = conn.executeQueryWithParams(query,parameters);
            return conn.checkRowsAffected(rowsAffected);
        }
        #endregion
    }
}
