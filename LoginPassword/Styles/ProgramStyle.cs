using System.Runtime.Serialization;

namespace LoginPassword
{
    [DataContract]
    public class ProgramStyle
    {
        [DataMember]
        public string IconBrushes { get; set; }
        [DataMember]
        public string UpGridBrushes { get; set; }
        [DataMember]
        public string GridMenyBrushes { get; set; }
    }
}
