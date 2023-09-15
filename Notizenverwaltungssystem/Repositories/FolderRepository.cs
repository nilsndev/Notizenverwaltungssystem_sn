using Notizenverwaltungssystem.Models;
using Notizenverwaltungssystem.otherClasses;

namespace Notizenverwaltungssystem.Repositories{
    public static class FolderRepository{
        #region Methods
        public static bool AddFolder(Folder folder) {
            connection_class conn = connection_class.getInstance();
            string query = "INSERT INTO folder (folder_name,userName)"
                + $" VALUES('{folder.FolderName}','{Settings.ActiveUserName}')";
            int rowsAffected = conn.executeQuery(query);
            return conn.checkRowsAffected(rowsAffected);
        }
        public static Folder[] GetFoldersByUserName(){
            connection_class conn = connection_class.getInstance();
            string query = $"SELECT * FROM folder WHERE userName = '{Settings.ActiveUserName}'";
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
            string query = $"UPDATE folder SET folder_name = '{updatedFolder.FolderName}' WHERE ID = {updatedFolder.ID}";
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
