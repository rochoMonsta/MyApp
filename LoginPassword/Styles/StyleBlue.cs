using System.Runtime.Serialization;

namespace LoginPassword.Styles
{
    [DataContract]
    class StyleBlue : ProgramStyle
    {
        public StyleBlue()
        {
            IconBrushes = "#ffffff";
            UpGridBrushes = "#2773ba";
            GridMenyBrushes = "#0f4980";
            ChangePhoto = "#0f4980";
        }
    }
}
