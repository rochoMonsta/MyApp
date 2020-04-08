using System.Runtime.Serialization;

namespace LoginPassword.Styles
{
    [DataContract]
    class StyleDefault : ProgramStyle
    {
        public StyleDefault()
        {
            IconBrushes = "#FF686868";
            UpGridBrushes = "#FF686868";
            GridMenyBrushes = "#FF2C2C2C";
            ChangePhoto = "#FF686868";
        }
    }
}
