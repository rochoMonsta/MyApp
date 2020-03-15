using System.IO;
using System.Runtime.Serialization.Json;

namespace LoginPassword
{
    class Saver
    {
        public void SAVE_USER(JSONDataBase user_list)
        {
            var json_formatter = new DataContractJsonSerializer(typeof(JSONDataBase));

            using (var file = new FileStream("UserList.json", FileMode.Create))
                json_formatter.WriteObject(file, user_list);
        }
        public JSONDataBase LOAD_USER()
        {
            var json_formatter = new DataContractJsonSerializer(typeof(JSONDataBase));

            using (var file = new FileStream("UserList.json", FileMode.OpenOrCreate))
            {
                var user_list = json_formatter.ReadObject(file) as JSONDataBase;
                if (user_list != null)
                    return user_list;
            }
            return null;
        }
    }
}