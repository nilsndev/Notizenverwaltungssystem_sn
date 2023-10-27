using Notizenverwaltungssystem.Models;
using Notizenverwaltungssystem.otherClasses;
using System.Collections;

namespace Notizenverwaltungssystem.Repositories{
    public static class NoteRepository{
        #region Methods
        public static bool addOneNote(Note note){
            string query = "";
            connection_class conn = connection_class.getInstance();
            string insertQuery = "INSERT INTO note (note_text, userName, title, folderID) " +
                "VALUES (@noteText, @userName, @title, @folderID)";
            var parameters = new Hashtable{
                { "@noteText", note.Note_Text },
                { "@userName", Settings.ActiveUserName },
                { "@title", note.Title },
                { "@folderID", note.FolderID ?? (object)DBNull.Value }
            };
            int rowsAffected = conn.executeQueryWithParams(insertQuery, parameters);
            return conn.checkRowsAffected(rowsAffected);
        }
        public static bool UpdateOne(Note updatedNote){
            string query = "UPDATE note SET title = @title, note_text = @noteText WHERE ID = @noteID";
            var parameters = new Hashtable{
                { "@title", updatedNote.Title },
                { "@noteText", updatedNote.Note_Text },
                { "@noteID", updatedNote.ID }
            };
            connection_class conn = connection_class.getInstance();
            int rowsAffected = conn.executeQueryWithParams(query, parameters);
            return conn.checkRowsAffected(rowsAffected);
        }
        public static bool DeleteOneNote(int noteID){
            connection_class conn = connection_class.getInstance();
            string query = "DELETE FROM note WHERE (ID = @noteID)";
            var parameters = new Hashtable{
                { "@noteID", noteID }
            };
            int rowsAffected = conn.executeQueryWithParams(query, parameters);
            return conn.checkRowsAffected(rowsAffected);
        }
        public static Note[] GetNotesByUserName(){
            connection_class conn = connection_class.getInstance();
            string query = "SELECT * FROM note WHERE userName = @userName AND folderID IS NULL";

            var parameters = new Dictionary<string, object>{
                { "@userName", Settings.ActiveUserName }
            };
            Note[] notes = conn.ReturnValuesFromParameterizedQuery(query, parameters, reader =>{
                return new Note(
                    Convert.ToInt32(reader["ID"]),
                    userName: reader["userName"].ToString(),
                    title: reader["title"].ToString(),
                    note_text: reader["note_text"].ToString()
                );
            });
            return notes;
        }
        public static Note[] GetNotesByUserNameFolderID(int folderID){
            connection_class conn = connection_class.getInstance();
            string query = "SELECT * FROM note WHERE userName = @userName AND folderID = @folderID";
            var parameters = new Dictionary<string, object>{
                { "@userName", Settings.ActiveUserName },
                { "@folderID", folderID }
            };
            Note[] notes = conn.ReturnValuesFromParameterizedQuery(query, parameters, reader =>{
                return new Note(
                    Convert.ToInt32(reader["ID"]),
                    userName: reader["userName"].ToString(),
                    title: reader["title"].ToString(),
                    note_text: reader["note_text"].ToString(),
                    folderID: Convert.ToInt32(reader["folderID"])
                );
            });
            return notes;
        }
        #endregion
    }
}
