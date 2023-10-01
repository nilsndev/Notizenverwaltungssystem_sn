using Notizenverwaltungssystem.Models;
using Notizenverwaltungssystem.otherClasses;
using Org.BouncyCastle.Asn1.X509;

namespace Notizenverwaltungssystem.Repositories{
    public static class FolderRepository{
        #region Methods
        public static bool AddFolder(Folder folder) {
            connection_class conn = connection_class.getInstance();
            string query = "";
            parentFolderNULL(ref query, folder);
            int rowsAffected = conn.executeQuery(query);
            return conn.checkRowsAffected(rowsAffected);
        }
        static void parentFolderNULL(ref string query,Folder folder){
            if(folder.ParentFolderID == 0 || folder.ParentFolderID == null){
                query = "INSERT INTO folder (folder_name,userName)"
                + $" VALUES('{folder.FolderName}','{Settings.ActiveUserName}')";
            }
            else{
                query = "INSERT INTO folder (folder_name,userName,parent_folder_ID)"
                + $" VALUES('{folder.FolderName}','{Settings.ActiveUserName}',{folder.ParentFolderID})";
            }

        }
        public static Folder[] GetFoldersByUserName(){
            connection_class conn = connection_class.getInstance();
            string query = $"SELECT * FROM folder WHERE userName = '{Settings.ActiveUserName}' AND parent_folder_ID IS NULL";
            Folder[] folders = conn.ReturnValuesFromQuery(query, reader => {
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
            string query = $"SELECT * FROM folder WHERE userName = '{Settings.ActiveUserName}' AND parent_folder_ID ={id}";
            Folder[] folders = conn.ReturnValuesFromQuery(query, reader => {
                return new Folder(
                    Convert.ToInt32(reader["ID"]),
                    folderName: reader["folder_name"].ToString(),
                    userName: reader["userName"].ToString()
                        );
            });
            return folders;
        }
        public static bool updateOne(Folder updatedFolder){
            string query = "";
            if(updatedFolder.ParentFolderID != null){
                query = $"UPDATE folder SET folder_name = '{updatedFolder.FolderName}', parent_folder_ID = {updatedFolder.ParentFolderID}  WHERE ID = {updatedFolder.ID}";
            }
            else{
                query = $"UPDATE folder SET folder_name = '{updatedFolder.FolderName}' WHERE ID = {updatedFolder.ID}";
            }
            connection_class conn = connection_class.getInstance();
            int rowsAffected = conn.executeQuery(query);
            return conn.checkRowsAffected(rowsAffected);
        }
        public static bool deleteOneFolder(int noteID){
            connection_class conn = connection_class.getInstance();
            string query = $"DELETE FROM folder WHERE (ID = {noteID}) ";
            int rowsAffected = conn.executeQuery(query);
            return conn.checkRowsAffected(rowsAffected);
        }
        #endregion
    }
}
