﻿using Microsoft.Win32;
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
    /// Логика взаимодействия для LibraryFilms.xaml
    /// </summary>
    public partial class LibraryFilms : Page
    {
        public string PhotoLinkString;
        public User user;
        public LibraryFilms()
        {
            InitializeComponent();
            SortingLib.Visibility = Visibility.Hidden;
            SertedMenu.Visibility = Visibility.Hidden;
            user = User.currentUser;
            if (user != null)
            {
                LibraryName.Text = UserLibrari.currentUserLibrari.Name;
                CountOfItemInLibrary.Text = "Count of films : " + UserLibrari.currentUserLibrari.filmsInLibrari.Count.ToString();
                if (UserLibrari.currentUserLibrari.filmsInLibrari.Count == 0)
                    MidleMark.Text = "Average score : 0";
                else
                    MidleMark.Text = "Average score : " + GetAverageScore(UserLibrari.currentUserLibrari.filmsInLibrari);

                if (UserLibrari.currentUserLibrari.Link != null)
                    LibraryImage.Source = new BitmapImage(new Uri(UserLibrari.currentUserLibrari.Link));
                else
                    LibraryImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/screen-0.jpg"));

                foreach (var element in UserLibrari.currentUserLibrari.filmsInLibrari)
                    LibraryFilmsWrapPannel.Children.Add(CreateNewButton(element));
            }
        }
        private void SortByMarkUp_Click(object sender, RoutedEventArgs e)
        {
            UserLibrari.currentUserLibrari.filmsInLibrari = UserLibrari.currentUserLibrari.filmsInLibrari.OrderBy(film => film.Mark).ThenBy(film => film.Name).ToList();
            var page = new LibraryFilms();
            NavigationService.Navigate(page);
        }

        private void SortByMarkDown_Click(object sender, RoutedEventArgs e)
        {
            UserLibrari.currentUserLibrari.filmsInLibrari = UserLibrari.currentUserLibrari.filmsInLibrari.OrderByDescending(film => film.Mark).ThenBy(film => film.Name).ToList();
            var page = new LibraryFilms();
            NavigationService.Navigate(page);
        }

        private void SortByNameUp_Click(object sender, RoutedEventArgs e)
        {
            UserLibrari.currentUserLibrari.filmsInLibrari = UserLibrari.currentUserLibrari.filmsInLibrari.OrderBy(film => film.Name).ToList();
            var page = new LibraryFilms();
            NavigationService.Navigate(page);
        }

        private void SortByNameDown_Click(object sender, RoutedEventArgs e)
        {
            UserLibrari.currentUserLibrari.filmsInLibrari = UserLibrari.currentUserLibrari.filmsInLibrari.OrderByDescending(film => film.Name).ToList();
            var page = new LibraryFilms();
            NavigationService.Navigate(page);
        }
        private void AddFilmToLibraryButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new AddFilmsToLibraryMenu();
            NavigationService.Navigate(page);
        }

        private void DeleteLibraryButton_Click(object sender, RoutedEventArgs e)
        {
            user.userLibraris.RemoveAt(UserLibrari.currentUserLibrariIndex);
            var page = new Librari();
            NavigationService.Navigate(page);
        }

        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                PhotoLinkString = openDialog.FileName;
            }
            UserLibrari.currentUserLibrari.Link = PhotoLinkString;
            user.userLibraris[UserLibrari.currentUserLibrariIndex].Link = PhotoLinkString;

            var CurrentLibraryPage = new LibraryFilms();
            NavigationService.Navigate(CurrentLibraryPage);
        }

        private void ChangeName_Click(object sender, RoutedEventArgs e)
        {
            LibraryName.IsReadOnly = false;
            LibraryName.BorderThickness = new Thickness(0.5);
            LibraryName.BorderBrush = Brushes.Blue;
        }

        private void SaveChanged_Click(object sender, RoutedEventArgs e)
        {
            LibraryName.IsReadOnly = true;
            UserLibrari.currentUserLibrari.Name = LibraryName.Text;
            user.userLibraris[UserLibrari.currentUserLibrariIndex].Name = LibraryName.Text;
            LibraryName.BorderThickness = new Thickness(0);
        }
        public string GetAverageScore(List<Film> listOfFilms)
        {
            double score = 0.0;
            foreach (var element in listOfFilms)
                score += element.Mark;
            score /= listOfFilms.Count;
            return Math.Round(score, 1).ToString();
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
        private void YourButtonClick(object sender, EventArgs e)
        {
            int indexOfFilm = LibraryFilmsWrapPannel.Children.IndexOf(sender as UIElement);
            Film.CurrentFilm = UserLibrari.currentUserLibrari.filmsInLibrari[indexOfFilm];
            Film.CurrentFilmIndex = indexOfFilm;
            var filmInfo = new FilmInfoInLibrary();
            NavigationService.Navigate(filmInfo);
        }
    }
}
