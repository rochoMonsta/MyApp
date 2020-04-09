using System.Runtime.Serialization;

namespace LoginPassword.Styles
{
    [DataContract]
    class StyleRed : ProgramStyle
    {
        public StyleRed()
        {
            IconBrushes = "#ffffff";
            UpGridBrushes = "#a81d1d";
            GridMenyBrushes = "#7d0a0a";
            ChangePhoto = "#7d0a0a";
        }
    }
}
