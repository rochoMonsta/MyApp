using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoginPassword
{
    [DataContract]
    public class UserLibrari
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public List<Film> filmsInLibrari = new List<Film>();
        public static UserLibrari currentUserLibrari;
        public static int currentUserLibrariIndex;
        public UserLibrari() { }
        public UserLibrari(string Name, string Link)
        {
            this.Name = Name;
            this.Link = Link;
        }

    }
}
