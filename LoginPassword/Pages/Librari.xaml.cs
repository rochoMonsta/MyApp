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
    /// Логика взаимодействия для Librari.xaml
    /// </summary>
    public partial class Librari : Page
    {
        public User user;
        public Librari()
        {
            InitializeComponent();
            user = User.currentUser;
            if (user != null)
            {
                if (user.userLibraris != null)
                {
                    foreach (var element in user.userLibraris)
                    {
                        LibrariWrapPannel.Children.Add(CreateNewLibrariButton(element));
                    }
                }
            }
        }

        private void AddNewLibrari_Click(object sender, RoutedEventArgs e)
        {
            var createNewLibrari = new CreateNewLibrariPage();
            NavigationService.Navigate(createNewLibrari);
        }
        public Button CreateNewLibrariButton(UserLibrari userLibrari)
        {
            Button button = new Button();
            button.Margin = new Thickness(5);
            button.Style = (Style)FindResource("myButtonStyle");
            button.Click += new RoutedEventHandler(YourButtonClick);
            button.BorderBrush = null;

            ImageBrush imageBrush = new ImageBrush();
            try
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(userLibrari.Link));
            }
            catch (Exception)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/screen-0.jpg"));
            }
            imageBrush.Stretch = Stretch.UniformToFill;
            button.Background = imageBrush;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Background = Brushes.Black;
            stackPanel.Opacity = new Double();
            stackPanel.Opacity = 0.8;
            stackPanel.Height = 30;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = userLibrari.Name;
            textBlock.Foreground = Brushes.White;
            textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.FontSize = 14;
            textBlock.FontWeight = FontWeights.Light;
            textBlock.FontFamily = new FontFamily("helvetica");
            textBlock.Margin = new Thickness(3, 0, 3, 0);
            stackPanel.Children.Add(textBlock);

            button.Content = stackPanel;
            return button;
        }
        private void YourButtonClick(object sender, EventArgs e)
        {
            int indexOfLibrari = LibrariWrapPannel.Children.IndexOf(sender as UIElement) - 1;
            UserLibrari.currentUserLibrari = user.userLibraris[indexOfLibrari];
            UserLibrari.currentUserLibrariIndex = indexOfLibrari;
            var page = new LibraryFilms();
            NavigationService.Navigate(page);
            //MessageBox.Show("Номер" + indexOfLibrari);
        }
    }
}
