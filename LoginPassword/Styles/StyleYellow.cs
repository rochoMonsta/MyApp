using System.Runtime.Serialization;

namespace LoginPassword.Styles
{
    [DataContract]
    class StyleYellow : ProgramStyle
    {
        public StyleYellow()
        {
            IconBrushes = "#ffffff";
            UpGridBrushes = "#d1d128";
            GridMenyBrushes = "#9c9c10";
            ChangePhoto = "#9c9c10";
        }
    }
}
