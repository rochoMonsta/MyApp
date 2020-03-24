using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LoginPassword
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public List<Film> films = new List<Film>();
        [DataMember]
        public string AvatarLink { get; set; }
        [DataMember]
        public List<UserLibrari> userLibraris = new List<UserLibrari>();
        //internal List<Film> Films { get => films; set => films = value; }
        public static User currentUser;
        public User() { }
        public User(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
        public override string ToString()
        {
            return $"Login: {Login}; Password: {Password}";
        }
    }
}
