using System.Runtime.Serialization;

namespace LoginPassword.Styles
{
    [DataContract]
    class StyleGreen : ProgramStyle
    {
        public StyleGreen()
        {
            IconBrushes = "#ffffff";
            UpGridBrushes = "#1da346";
            GridMenyBrushes = "#1c6332";
            ChangePhoto = "#1c6332";
        }
    }
}
