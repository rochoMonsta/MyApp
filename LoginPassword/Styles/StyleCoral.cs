using System.Runtime.Serialization;

namespace LoginPassword.Styles
{
    [DataContract]
    class StyleCoral : ProgramStyle
    {
        public StyleCoral()
        {
            IconBrushes = "#ffffff";
            UpGridBrushes = "#2ad1c0";
            GridMenyBrushes = "#289c90";
            ChangePhoto = "#289c90";
        }
    }
}
