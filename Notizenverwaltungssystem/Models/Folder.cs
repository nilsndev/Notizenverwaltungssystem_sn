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

        #endregion
        #region Fields
        int _id;
        string _folderName;
        string _userName;
        Note[] _notes;
        #endregion
        #region Characteristics
        [JsonPropertyName("id")]
        public int ID { get { return _id; } set { _id = value; } }
        [JsonPropertyName("folderName")]
        public string FolderName { get { return _folderName; } set { _folderName = value; } }
        [JsonPropertyName("userName")]
        public string UserName { get { return _userName; } set { _userName = value; } }
        public Note[] Notes { get { return _notes; } set { _notes = value; } }
        #endregion
        #region Methods 
        #endregion
    }
}
