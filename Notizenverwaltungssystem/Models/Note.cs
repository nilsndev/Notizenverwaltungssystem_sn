using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Notizenverwaltungssystem.Models{
    public class Note{
        #region Constructors
        public Note() 
        { }
        public Note(int id, string userName, string title){
            _id = id;
            _userName = userName;
            _title = title;
        }
        public Note(int id, string userName, string title,string note_text){
            _id = id;
            _userName = userName;
            _title = title;
            _note_text = note_text;
        }
        public Note(int id, string userName, string title, string note_text,int folderID){
            _id = id;
            _userName = userName;
            _title = title;
            _note_text = note_text;
            _folderID = folderID;
        }
        #endregion
        #region Fields
        int _id;
         string _note_text;
         string _userName;
         string _title;
        int _folderID;
        #endregion
        #region Characteristics
        [JsonPropertyName("id")]
        public int ID { 
            get{
                return _id; 
            } 
            set{
                if( value > 0){
                    _id = value;
                }
            } 
        }
        [JsonPropertyName("userName")]
        public string UserName { 
            get { 
                return _userName; 
            } 
            set { 
                _userName = value; 
            } 
        }
        [JsonPropertyName("note_text")]
        public string Note_Text{
            get{
                return _note_text;
            }
            set{
                _note_text = value;
            }
        }
        [JsonPropertyName("title")]
        public string Title{
            get{
                return _title;
            }
            set{
                _title = value;
            }
        }
        #endregion
        #region Methods
        #endregion

    }
}
