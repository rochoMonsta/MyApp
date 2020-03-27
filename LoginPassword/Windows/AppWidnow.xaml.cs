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

        public static List<Film> userFilmsListCopy = new List<Film>();
        public bool IsOpen = false;
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
                if (user.Username == null)
                    UserName.Text = user.Login;
                else
                    UserName.Text = user.Username;
            }
            if (IsOpen != true && user.films != null)
                userFilmsListCopy = user.films;
            IsOpen = true;
        }

        private void ButtonPopupBoxLogout_Click(object sender, RoutedEventArgs e)
        {
            Saver saver = new Saver();
            var user_list = saver.LOAD_USER();
            user.films = userFilmsListCopy;
            int index = user_list.GetUserIndex(user);
            user_list.ChangeUserInfo(user, index);
            saver.SAVE_USER(user_list);

            MainWindow loginWindow = new MainWindow();
            this.Hide();
            loginWindow.ShowDialog();
            this.Show();
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
            var FilmPage = new AddFilmPage();
            FilmMain.Navigate(FilmPage);
            WelcomeTextBlock.Text = "Add film";
        }

        private void AllFilms_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var AllFilmPage = new AllFilmsPage();
            FilmMain.Navigate(AllFilmPage);
            WelcomeTextBlock.Text = "All films";
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Saver saver = new Saver();
            var user_list = saver.LOAD_USER();
            user.films = userFilmsListCopy;
            int index = user_list.GetUserIndex(user);
            user_list.ChangeUserInfo(user, index);
            saver.SAVE_USER(user_list);
            Application.Current.Shutdown();
        }

        private void OpenLibrari_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var LibrariPage = new Librari();
            FilmMain.Navigate(LibrariPage);
            WelcomeTextBlock.Text = "Library";
        }

        private void SortByMarkUp_Click(object sender, RoutedEventArgs e)
        {
            user.films = user.films.OrderBy(film => film.Mark).ThenBy(film => film.Name).ToList();
            var AllFilmsPage = new AllFilmsPage();
            FilmMain.Navigate(AllFilmsPage);
            WelcomeTextBlock.Text = "All films";
        }

        private void SortByMarkDown_Click(object sender, RoutedEventArgs e)
        {
            user.films = user.films.OrderByDescending(film => film.Mark).ThenBy(film => film.Name).ToList();
            var AllFilmsPage = new AllFilmsPage();
            FilmMain.Navigate(AllFilmsPage);
            WelcomeTextBlock.Text = "All films";
        }

        private void SortByNameUp_Click(object sender, RoutedEventArgs e)
        {
            user.films = user.films.OrderBy(film => film.Name).ToList();
            var AllFilmsPage = new AllFilmsPage();
            FilmMain.Navigate(AllFilmsPage);
            WelcomeTextBlock.Text = "All films";
        }

        private void SortByNameDown_Click(object sender, RoutedEventArgs e)
        {
            user.films = user.films.OrderByDescending(film => film.Name).ToList();
            var AllFilmsPage = new AllFilmsPage();
            FilmMain.Navigate(AllFilmsPage);
            WelcomeTextBlock.Text = "All films";
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new AccountSettings();
            FilmMain.Navigate(page);
            WelcomeTextBlock.Text = "Account settings";
        }
    }
}
