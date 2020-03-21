using LoginPassword.Pages;
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
using System.Windows.Shapes;

namespace LoginPassword.Windows
{
    /// <summary>
    /// Логика взаимодействия для AppWidnow.xaml
    /// </summary>
    public partial class AppWidnow : Window
    {
        public static User user;
        public AppWidnow()
        {
            InitializeComponent();
            user = User.currentUser;
            if (user != null)
            {
                try
                {
                    UserProfileImage.Source = new BitmapImage(new Uri(user.AvatarLink));
                }
                catch(Exception) { }
                UserName.Text = user.Login;
            }
        }

        private void ButtonPopupBoxLogout_Click(object sender, RoutedEventArgs e)
        {
            Saver saver = new Saver();
            var user_list = saver.LOAD_USER();
            int index = user_list.GetUserIndex(user);
            user_list.ChangeUserInfo(user, index);
            saver.SAVE_USER(user_list);
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void ChangeUserPhoto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                UserProfileImage.Source = new BitmapImage(new Uri(openDialog.FileName));
                user.AvatarLink = openDialog.FileName;
            }
        }

        private void AddFilmToUserFilmList_Click(object sender, RoutedEventArgs e)
        {
            FilmMain.Content = new AddFilmPage();
            WelcomeTextBlock.Text = "Add film";
        }

        private void AllFilms_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FilmMain.Content = new AllFilmsPage();
            WelcomeTextBlock.Text = "All films";
        }
    }
}
