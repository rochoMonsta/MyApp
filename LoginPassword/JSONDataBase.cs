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
        public bool CheckForCorrectUserAndPassword(User user)
        {
            User UserByLogin = new User();
            var IsCreatedLogin = ListOfUsers.Any(item => item.Login == user.Login);
            if (IsCreatedLogin)
                UserByLogin = ListOfUsers.Last(item => item.Login == user.Login);
            if (UserByLogin == null) { return false; }
            if (IsCreatedLogin && UserByLogin.Password == user.Password)
                return true;
            else
                return false;
        }
    }
}
