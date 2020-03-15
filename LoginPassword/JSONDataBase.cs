using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool ListContains(User user)
        {
            var IsCreated = ListOfUsers.Any(item => item.Login == user.Login);
            if (IsCreated)
                return true;
            else
                return false;
        }
    }
}
