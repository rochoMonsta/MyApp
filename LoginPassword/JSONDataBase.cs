using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LoginPassword
{
    [DataContract]
    class JSONDataBase
    {
        [DataMember]
        private List<User> ListOfUsers = new List<User>();
        public void AddNewUser(User user)
        {
            ListOfUsers.Add(user);
        }
    }
}
