using LoginPassword.Styles;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LoginPassword.Pages
{
    public partial class ProgramSettings : Page
    {
        public static User user;
        public ProgramSettings()
        {
            InitializeComponent();
            user = User.currentUser;
        }

        private void PurpleStyleButton_Click(object sender, RoutedEventArgs e)
        {
            user.ProgramStyle = new StylePurple();
            PurpleStyleButton.Opacity = 0.4;

            GreenStyleButton.Opacity = 1.0;
            DefaultStyleButton.Opacity = 1.0;
            CoralStyleButton.Opacity = 1.0;
            RedStyleButton.Opacity = 1.0;
            BlueStyleButton.Opacity = 1.0;
            YellowStyleButton.Opacity = 1.0;
            OrangeStyleButton.Opacity = 1.0;
        }

        private void GreenStyleButton_Click(object sender, RoutedEventArgs e)
        {
            user.ProgramStyle = new StyleGreen();
            GreenStyleButton.Opacity = 0.4;

            PurpleStyleButton.Opacity = 1.0;
            DefaultStyleButton.Opacity = 1.0;
            CoralStyleButton.Opacity = 1.0;
            RedStyleButton.Opacity = 1.0;
            BlueStyleButton.Opacity = 1.0;
            YellowStyleButton.Opacity = 1.0;
            OrangeStyleButton.Opacity = 1.0;
        }

        private void DefaultStyleButton_Click(object sender, RoutedEventArgs e)
        {
            user.ProgramStyle = new StyleDefault();
            DefaultStyleButton.Opacity = 0.4;

            GreenStyleButton.Opacity = 1.0;
            PurpleStyleButton.Opacity = 1.0;
            CoralStyleButton.Opacity = 1.0;
            RedStyleButton.Opacity = 1.0;
            BlueStyleButton.Opacity = 1.0;
            YellowStyleButton.Opacity = 1.0;
            OrangeStyleButton.Opacity = 1.0;
        }

        private void SaveAdvancedSett_Click(object sender, RoutedEventArgs e)
        {
            var programStyle = new ProgramStyle()
            {
                IconBrushes = IconColorPicker.SelectedColorText,
                UpGridBrushes = UpGridColorPicker.SelectedColorText,
                GridMenyBrushes = GridMenyColorPicker.SelectedColorText,
                ChangePhoto = GridMenyColorPicker.SelectedColorText
            };
            user.ProgramStyle = programStyle;
            var page = new AllFilmsPage();
            NavigationService.Navigate(page);
        }

        private void CoralStyleButton_Click(object sender, RoutedEventArgs e)
        {
            user.ProgramStyle = new StyleCoral();
            CoralStyleButton.Opacity = 0.4;

            GreenStyleButton.Opacity = 1.0;
            PurpleStyleButton.Opacity = 1.0;
            DefaultStyleButton.Opacity = 1.0;
            RedStyleButton.Opacity = 1.0;
            BlueStyleButton.Opacity = 1.0;
            YellowStyleButton.Opacity = 1.0;
            OrangeStyleButton.Opacity = 1.0;
        }

        private void RedStyleButton_Click(object sender, RoutedEventArgs e)
        {
            user.ProgramStyle = new StyleRed();
            RedStyleButton.Opacity = 0.4;

            GreenStyleButton.Opacity = 1.0;
            PurpleStyleButton.Opacity = 1.0;
            DefaultStyleButton.Opacity = 1.0;
            CoralStyleButton.Opacity = 1.0;
            BlueStyleButton.Opacity = 1.0;
            YellowStyleButton.Opacity = 1.0;
            OrangeStyleButton.Opacity = 1.0;
        }

        private void BlueStyleButton_Click(object sender, RoutedEventArgs e)
        {
            user.ProgramStyle = new StyleBlue();
            BlueStyleButton.Opacity = 0.4;

            GreenStyleButton.Opacity = 1.0;
            PurpleStyleButton.Opacity = 1.0;
            DefaultStyleButton.Opacity = 1.0;
            CoralStyleButton.Opacity = 1.0;
            RedStyleButton.Opacity = 1.0;
            YellowStyleButton.Opacity = 1.0;
            OrangeStyleButton.Opacity = 1.0;
        }

        private void YellowStyleButton_Click(object sender, RoutedEventArgs e)
        {
            user.ProgramStyle = new StyleYellow();
            YellowStyleButton.Opacity = 0.4;

            GreenStyleButton.Opacity = 1.0;
            PurpleStyleButton.Opacity = 1.0;
            DefaultStyleButton.Opacity = 1.0;
            CoralStyleButton.Opacity = 1.0;
            RedStyleButton.Opacity = 1.0;
            BlueStyleButton.Opacity = 1.0;
            OrangeStyleButton.Opacity = 1.0;
        }

        private void OrangeStyleButton_Click(object sender, RoutedEventArgs e)
        {
            user.ProgramStyle = new StyleOrange();
            OrangeStyleButton.Opacity = 0.4;

            GreenStyleButton.Opacity = 1.0;
            PurpleStyleButton.Opacity = 1.0;
            DefaultStyleButton.Opacity = 1.0;
            CoralStyleButton.Opacity = 1.0;
            RedStyleButton.Opacity = 1.0;
            BlueStyleButton.Opacity = 1.0;
            YellowStyleButton.Opacity = 1.0;
        }
    }
}
