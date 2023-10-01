using Notizenverwaltungssystem.Models;
using Notizenverwaltungssystem.otherClasses;


namespace Notizenverwaltungssystem.Repositories{
    public static class NoteRepository{
        #region Methods
        public static bool addOneNote(Note note){
            string query = "";
            Console.Write(note.FolderID);
            connection_class conn = connection_class.getInstance();
            if(note.FolderID != null){
                query = "INSERT INTO note(note_text,userName,title,folderID)" +
               " VALUES('" + note.Note_Text + "','" + Settings.ActiveUserName + "','" + note.Title + "'," + note.FolderID + ")";
            }
            else{
                query = "INSERT INTO note(note_text,userName,title)" +
              " VALUES('" + note.Note_Text + "','" + Settings.ActiveUserName + "','" + note.Title + "')";
            }
           
            int rowsAffected = conn.executeQuery(query);
            return conn.checkRowsAffected(rowsAffected);
        }
        public static bool updateOne(Note updatedNote){
            string query = $"UPDATE note SET title = '{updatedNote.Title}', note_text = '{updatedNote.Note_Text}' WHERE ID = {updatedNote.ID}";
            connection_class conn = connection_class.getInstance();
            int rowsAffected = conn.executeQuery(query);
            
            return conn.checkRowsAffected(rowsAffected);
        }
        public static bool deleteOneNote(int noteID){
            connection_class conn = connection_class.getInstance();
            string query = $"DELETE FROM note WHERE (ID = {noteID}) ";
            int rowsAffected = conn.executeQuery(query);
            return conn.checkRowsAffected(rowsAffected);
        }
      
        public static Note[] getNotesbyUserName(){
           connection_class conn = connection_class.getInstance();
            string query = $"SELECT * FROM note WHERE userName = '{Settings.ActiveUserName}' AND folderID IS NULL";
            Note[] notes = conn.ReturnValuesFromQuery(query, reader =>{
                return new Note(
                    Convert.ToInt32(reader["ID"]),
                    userName: reader["userName"].ToString(),
                    title: reader["title"].ToString(),
                    note_text: reader["note_text"].ToString()
                        ) ;
            });
            return notes;
        }
        public static Note[] getNotesbyUserNameFolderID(int folderID){
            connection_class conn = connection_class.getInstance();
            string query = $"SELECT * FROM note WHERE userName = '{Settings.ActiveUserName}' AND folderID = {folderID}";
            Note[] notes = conn.ReturnValuesFromQuery(query, reader => {
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
