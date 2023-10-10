namespace Notizenverwaltungssystem.otherClasses
{
    public static class Settings{
        #region Fields
        static string _activeUserName = "";
        static int _activeOTP;
        #endregion
        #region Characteristics
        public static string ActiveUserName { get {  return _activeUserName; } set { _activeUserName = value; } }
        public static int ActiveOTP { get { return _activeOTP; }set { _activeOTP = value; } }  

        #endregion
        #region Methods
        #endregion

    }
}
