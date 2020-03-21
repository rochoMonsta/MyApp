using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoginPassword.Windows;
using LoginPassword.Pages;

namespace LoginPassword.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddFilmPage.xaml
    /// </summary>
    public partial class AddFilmPage : Page
    {
        public static string PhotoLinkString;
        public static User user;

        public object FilmMain { get; private set; }

        public AddFilmPage()
        {
            InitializeComponent();
            user = User.currentUser;
        }
        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Text_button.Text = "";
        }

        private void PhotoLink_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                PhotoLinkString = openDialog.FileName;
            }
        }

        private void AddFilmToUser_Click(object sender, RoutedEventArgs e)
        {
            var Film = new Film()
            {
                Name = Text_button.Text,
                Mark = Convert.ToDouble(MarkButton.Text),
                Link = PhotoLinkString
            };
            user.films.Add(Film);
        }

        private void MarkButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MarkButton.Text = "";
        }
    }
}
