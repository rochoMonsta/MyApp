using System.Runtime.Serialization;

namespace LoginPassword
{
    [DataContract]
    class User
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
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
