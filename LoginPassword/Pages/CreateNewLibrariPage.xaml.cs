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

namespace LoginPassword.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateNewLibrariPage.xaml
    /// </summary>
    public partial class CreateNewLibrariPage : Page
    {
        public static string PhotoLinkString;
        public static User user;
        public CreateNewLibrariPage()
        {
            InitializeComponent();
            user = User.currentUser;
        }

        private void LibrariPhotoLink_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                PhotoLinkString = openDialog.FileName;
            }
        }

        private void AddLibrariToUser_Click(object sender, RoutedEventArgs e)
        {
            var Librari = new UserLibrari()
            {
                Name = LibrariName_button.Text,
                Link = PhotoLinkString
            };
            user.userLibraris.Add(Librari);
            var LibrariPage = new Librari();
            NavigationService.Navigate(LibrariPage);
        }
        private void LibrariName_button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LibrariName_button.Text = "";
        }
    }
}
