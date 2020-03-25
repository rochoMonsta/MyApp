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
    /// Логика взаимодействия для AddFilmsToLibraryMenu.xaml
    /// </summary>
    public partial class AddFilmsToLibraryMenu : Page
    {
        public static User user;
        public static List<int> IndexOfSelectedFilms = new List<int>();
        public AddFilmsToLibraryMenu()
        {
            InitializeComponent();
            user = User.currentUser;
            if (user != null)
            {
                foreach (var element in user.films)
                {
                    FilmsWrapPannel.Children.Add(CreateNewButton(element));
                }
            }
        }
        private void AddSelectedFilmsToLibrary_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in IndexOfSelectedFilms)
            {
                if (user.userLibraris[UserLibrari.currentUserLibrariIndex].filmsInLibrari.Any(film => film.Name == user.films[element].Name) != true)
                    user.userLibraris[UserLibrari.currentUserLibrariIndex].filmsInLibrari.Add(user.films[element]);
            }
            IndexOfSelectedFilms.Clear();
            var page = new LibraryFilms();
            NavigationService.Navigate(page);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            IndexOfSelectedFilms.Clear();
            var page = new Librari();
            NavigationService.Navigate(page);
        }
        private void YourButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            int indexOfFilm = FilmsWrapPannel.Children.IndexOf(sender as UIElement);
            if (IndexOfSelectedFilms.Contains(indexOfFilm))
            {
                button.Opacity = 1.0;
                IndexOfSelectedFilms.Remove(indexOfFilm);
                SelectedFilms.Text = SelectedFilms.Text.Replace(user.films[indexOfFilm].Name + ", ", "");
            }
            else
            {
                SelectedFilms.Text += user.films[indexOfFilm].Name + ", ";
                IndexOfSelectedFilms.Add(indexOfFilm);
                button.Opacity = 0.2;
            }
        }
        public Button CreateNewButton(Film film)
        {
            Button button = new Button();
            button.Margin = new Thickness(5);
            button.Style = (Style)FindResource("myButtonStyle");
            button.BorderBrush = null;
            button.Click += new RoutedEventHandler(YourButtonClick);

            ImageBrush imageBrush = new ImageBrush();
            try
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(film.Link));
            }
            catch (Exception)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/screen-0.jpg"));
            }
            imageBrush.Stretch = Stretch.UniformToFill;

            button.Background = imageBrush;
            //father
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Background = Brushes.Black;
            stackPanel.Opacity = new Double();
            stackPanel.Opacity = 0.8;
            stackPanel.Height = 30;
            //children 1
            StackPanel filmNameStackPanel = new StackPanel();
            filmNameStackPanel.Orientation = Orientation.Horizontal;
            filmNameStackPanel.Width = 180;

            TextBlock FilmTextBlock = new TextBlock();
            FilmTextBlock.Text = film.Name;
            FilmTextBlock.Foreground = Brushes.White;
            FilmTextBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
            FilmTextBlock.TextAlignment = TextAlignment.Center;
            FilmTextBlock.VerticalAlignment = VerticalAlignment.Center;
            FilmTextBlock.FontSize = 14;
            FilmTextBlock.FontWeight = FontWeights.Light;
            FilmTextBlock.FontFamily = new FontFamily("helvetica");
            FilmTextBlock.Margin = new Thickness(3, 0, 3, 0);
            //children 1/
            filmNameStackPanel.Children.Add(FilmTextBlock);
            //children 2
            StackPanel markStackPanel = new StackPanel();
            markStackPanel.Orientation = Orientation.Horizontal;
            markStackPanel.Margin = new Thickness(3, 0, 0, 0);
            markStackPanel.Width = 40;

            MaterialDesignThemes.Wpf.PackIcon packIcon = new MaterialDesignThemes.Wpf.PackIcon();
            packIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.StarCircleOutline;
            packIcon.VerticalAlignment = VerticalAlignment.Center;
            packIcon.HorizontalAlignment = HorizontalAlignment.Center;
            packIcon.Foreground = Brushes.Gold;
            packIcon.Width = 20;
            packIcon.Height = 20;

            TextBlock markTextBlock = new TextBlock();
            markTextBlock.Text = film.Mark.ToString();
            markTextBlock.Foreground = Brushes.White;
            markTextBlock.HorizontalAlignment = HorizontalAlignment.Right;
            markTextBlock.TextAlignment = TextAlignment.Center;
            markTextBlock.VerticalAlignment = VerticalAlignment.Center;
            markTextBlock.FontFamily = new FontFamily("helvetica");
            markTextBlock.FontWeight = FontWeights.Light;
            markTextBlock.Margin = new Thickness(1, 0, 1, 0);
            markTextBlock.FontSize = 14;
            //children 2/
            markStackPanel.Children.Add(packIcon);
            markStackPanel.Children.Add(markTextBlock);
            //children 3
            StackPanel PopUpBoxStackPanel = new StackPanel();
            PopUpBoxStackPanel.Orientation = Orientation.Horizontal;

            MaterialDesignThemes.Wpf.PopupBox popupBox = new MaterialDesignThemes.Wpf.PopupBox();
            popupBox.PlacementMode = MaterialDesignThemes.Wpf.PopupBoxPlacementMode.BottomAndAlignRightEdges;
            popupBox.StaysOpen = true;
            popupBox.Foreground = Brushes.White;
            popupBox.HorizontalAlignment = HorizontalAlignment.Left;
            popupBox.VerticalAlignment = VerticalAlignment.Center;

            StackPanel stackPanel1 = new StackPanel();
            stackPanel1.Width = 100;

            Button button1 = new Button();
            StackPanel stackPanel2 = new StackPanel();
            stackPanel2.Orientation = Orientation.Horizontal;

            TextBlock insideTextBlock = new TextBlock();
            insideTextBlock.Text = "Change";
            insideTextBlock.FontSize = 14;
            insideTextBlock.TextAlignment = TextAlignment.Center;
            insideTextBlock.VerticalAlignment = VerticalAlignment.Center;
            insideTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            insideTextBlock.FontFamily = new FontFamily("helvetica");
            insideTextBlock.FontWeight = FontWeights.Light;

            MaterialDesignThemes.Wpf.PackIcon packIcon1 = new MaterialDesignThemes.Wpf.PackIcon();
            packIcon1.Kind = MaterialDesignThemes.Wpf.PackIconKind.Cached;
            packIcon1.Margin = new Thickness(4);

            stackPanel2.Children.Add(insideTextBlock);
            stackPanel2.Children.Add(packIcon1);
            //3.1
            button1.Content = stackPanel2;
            //3.2
            Separator separator = new Separator();

            //3.3
            Button button2 = new Button();
            //button2.Click += new RoutedEventHandler(YourButtonClick);
            StackPanel stackPanel3 = new StackPanel();
            stackPanel3.Orientation = Orientation.Horizontal;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Delete";
            textBlock.FontSize = 14;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.FontFamily = new FontFamily("helvetica");
            textBlock.FontWeight = FontWeights.Light;

            MaterialDesignThemes.Wpf.PackIcon packIcon2 = new MaterialDesignThemes.Wpf.PackIcon();
            packIcon2.Kind = MaterialDesignThemes.Wpf.PackIconKind.Delete;
            packIcon2.Margin = new Thickness(4);

            stackPanel3.Children.Add(textBlock);
            stackPanel3.Children.Add(packIcon2);

            button2.Content = stackPanel3;

            stackPanel1.Children.Add(button1);
            stackPanel1.Children.Add(separator);
            stackPanel1.Children.Add(button2);

            popupBox.PopupContent = stackPanel1;
            PopUpBoxStackPanel.Children.Add(popupBox);

            stackPanel.Children.Add(filmNameStackPanel);
            stackPanel.Children.Add(markStackPanel);
            stackPanel.Children.Add(PopUpBoxStackPanel);

            button.Content = stackPanel;

            return button;
        }
    }
}
