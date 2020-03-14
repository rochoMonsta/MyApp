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
        public bool ListContains(User user)
        {
            foreach (var element in ListOfUsers)
            {
                if (element.Login == user.Login)
                    return true;
                else
                    continue;
            }
            return false;
        }
    }
}
