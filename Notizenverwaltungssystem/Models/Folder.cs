using System.Text.Json.Serialization;
namespace Notizenverwaltungssystem.Models{
    public class Folder{
        #region Constructors
        public Folder(){
        }
        public Folder(int id, string folderName, string userName){
            _id = id;
            FolderName = folderName;
            UserName = userName;
        }
        public Folder(int id, string folderName, string userName,int? parent_folder_ID){
            _id = id;
            FolderName = folderName;
            UserName = userName;
            _parent_folder_ID = parent_folder_ID;

        }


        #endregion
        #region Fields
        int _id;
        string _folderName;
        string _userName;
        int? _parent_folder_ID;
        #endregion
        #region Characteristics
        [JsonPropertyName("id")]
        public int ID { get { return _id; } set { _id = value; } }
        [JsonPropertyName("folderName")]
        public string FolderName { get { return _folderName; } set { _folderName = value; } }
        [JsonPropertyName("userName")]
        public string UserName { get { return _userName; } set { _userName = value; } }
        [JsonPropertyName("parentFolderId")]
        public int? ParentFolderID { get { return _parent_folder_ID; } set {_parent_folder_ID = value; } }  
        #endregion
        #region Methods 
        #endregion
    }
}
