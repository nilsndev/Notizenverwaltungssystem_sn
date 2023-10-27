using System.Reflection;
using System.Text.Encodings.Web;

namespace Notizenverwaltungssystem.otherClasses{
    public static class Encoding{
        public static T EncodeObject<T>(T obj) where T: class{
            if(obj == null){
                return null;
            }
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach(var property in properties){
                if(property.PropertyType == typeof(string)){
                    string val = (string)property.GetValue(obj, null);
                    if(val != null){
                        val = HtmlEncoder.Default.Encode(val);
                        property.SetValue(obj, val, null);
                    }
                }
            }
            return obj;

        }
    }
}
