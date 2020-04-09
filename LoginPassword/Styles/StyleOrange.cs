using System.Runtime.Serialization;

namespace LoginPassword.Styles
{
    [DataContract]
    class StyleOrange : ProgramStyle
    {
        public StyleOrange()
        {
            IconBrushes = "#ffffff";
            UpGridBrushes = "#fc9403";
            GridMenyBrushes = "#a36002";
            ChangePhoto = "#a36002";
        }
    }
}
