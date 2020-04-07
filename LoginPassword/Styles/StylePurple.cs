using System.Runtime.Serialization;
using System.Windows.Media;

namespace LoginPassword.Styles
{
    [DataContract]
    class StylePurple : ProgramStyle
    {
        public StylePurple()
        {
            IconBrushes = "#ffffff";
            UpGridBrushes = "#b840b6";
            GridMenyBrushes = "#782977";
        }
    }
}
