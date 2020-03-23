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
    /// Логика взаимодействия для FilmInfo.xaml
    /// </summary>
    public partial class FilmInfo : Page
    {
        public Film film;
        public User user;
        public int index;
        public string PhotoLinkString;
        public bool IsChanged = false;
        public FilmInfo()
        {
            InitializeComponent();
            ChangePhoto.Visibility = Visibility.Hidden;
            film = Film.CurrentFilm;
            user = User.currentUser;
            index = Film.CurrentFilmIndex;
            if (film != null)
            {
                if (film.Link != null)
                    FilmImage.Source = new BitmapImage(new Uri(film.Link));
                else
                    FilmImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/screen-0.jpg"));
                FilmNameTextBlock.Text = film.Name;
                MarkTextBlock.Text = film.Mark.ToString();
                CommentTextBlock.Text = film.Comment;
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsChanged != true)
            {
                IsChanged = true;

                ChangePhoto.Visibility = Visibility.Visible;

                CommentTextBlock.IsReadOnly = false;
                FilmNameTextBlock.IsReadOnly = false;
                MarkTextBlock.IsReadOnly = false;

                SaveButtonText.Text = "Save";
            }
            else
            {
                user.films[index].Name = FilmNameTextBlock.Text;
                user.films[index].Mark = Convert.ToDouble(MarkTextBlock.Text);
                user.films[index].Comment = CommentTextBlock.Text;
                if (PhotoLinkString != null)
                    user.films[index].Link = PhotoLinkString;

                CommentTextBlock.IsReadOnly = true;
                FilmNameTextBlock.IsReadOnly = true;
                MarkTextBlock.IsReadOnly = true;

                SaveButtonText.Text = "Change";

                IsChanged = false;

                var page = new FilmInfo();
                NavigationService.Navigate(page);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            user.films.RemoveAt(index);
            var allFilmsPage = new AllFilmsPage();
            NavigationService.Navigate(allFilmsPage);
        }

        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                PhotoLinkString = openDialog.FileName;
            }
        }
    }
}
