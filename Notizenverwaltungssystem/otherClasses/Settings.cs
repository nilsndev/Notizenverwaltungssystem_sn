namespace Notizenverwaltungssystem.otherClasses
{
    public static class Settings{
        #region Fields
        static string _activeUserName = "";
        #endregion
        #region Characteristics
        public static string ActiveUserName { get {  return _activeUserName; } set { _activeUserName = value; } }
        #endregion
        #region Methods
        #endregion

    }
}
