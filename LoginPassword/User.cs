using LoginPassword.Styles;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LoginPassword
{
    [DataContract]
    [KnownType(typeof(StylePurple))]
    [KnownType(typeof(StyleGreen))]
    [KnownType(typeof(StyleDefault))]
    [KnownType(typeof(StyleCoral))]
    [KnownType(typeof(StyleRed))]
    [KnownType(typeof(StyleBlue))]
    [KnownType(typeof(StyleYellow))]
    [KnownType(typeof(StyleOrange))]
    public class User
    {
        [DataMember]
        public string Username { get; set; }
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
        [DataMember]
        public ProgramStyle ProgramStyle { get; set; }
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
