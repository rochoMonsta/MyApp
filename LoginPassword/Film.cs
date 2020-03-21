using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoginPassword
{
    [DataContract]
    public class Film
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public double Mark { get; set; }
        [DataMember]
        public string Comment { get; set; }
        public Film() { }
        public Film(string Name, string Link, double Mark, string Comment)
        {
            this.Name = Name;
            this.Link = Link;
            this.Mark = Mark;
            this.Comment = Comment;
        }
        public override string ToString()
        {
            return $"{Name} - {Link} - {Mark}";
        }
    }
}
