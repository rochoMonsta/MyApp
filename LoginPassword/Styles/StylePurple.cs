using System.Runtime.Serialization;

namespace LoginPassword.Styles
{
    [DataContract]
    class StylePurple : ProgramStyle
    {
        public StylePurple()
        {
            IconBrushes = "#ffffff";
            UpGridBrushes = "#6f2480";
            GridMenyBrushes = "#541263";
            ChangePhoto = "#541263";
        }
    }
}
