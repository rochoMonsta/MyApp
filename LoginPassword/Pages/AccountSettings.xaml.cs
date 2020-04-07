using LoginPassword.Windows;
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
    /// Логика взаимодействия для AccountSettings.xaml
    /// </summary>
    public partial class AccountSettings : Page
    {
        public User user;
        public bool IsChanged = false;
        public AccountSettings()
        {
            InitializeComponent();
            user = User.currentUser;
            CheckPasswordStackPanel.Visibility = Visibility.Hidden;
            SaveChanges.Visibility = Visibility.Hidden;
            try
            {
                UserImage.Source = new BitmapImage(new Uri(user.AvatarLink));
            }
            catch(Exception)
            {
                UserImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/screen-0.jpg"));
            }

            if (user.Username != null)
                UserUsername.Text = user.Username;
            else
                UserUsername.Text = "null";
            UserLogin.Text = user.Login;
        }

        private void ChangeUsernameAndLogin_Click(object sender, RoutedEventArgs e)
        {
            if (IsChanged != true)
            {
                ErrorLabel.Content = "";
                Password1.Content = "Enter your password";
                Password2.Content = "Enter your password again";
                CheckForCorrectPasswordTextBlock.Text = "Change username and login";
                CheckPasswordStackPanel.Visibility = Visibility.Visible;

                PasswordTextBox.IsReadOnly = false;
                Password2CheckTextBox.IsReadOnly = false;

                PasswordTextBox.BorderThickness = new Thickness(2);
                PasswordTextBox.BorderBrush = Brushes.Blue;
                Password2CheckTextBox.BorderThickness = new Thickness(2);
                Password2CheckTextBox.BorderBrush = Brushes.Blue;
            }
        }

        private void CheckForCorrectPassword_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForCorrectPasswordTextBlock.Text == "Change username and login")
            {
                if (PasswordTextBox.Text == user.Password && Password2CheckTextBox.Text == PasswordTextBox.Text)
                {
                    PasswordTextBox.IsReadOnly = true;
                    Password2CheckTextBox.IsReadOnly = true;
                    ErrorLabel.Content = "Success";
                    ErrorLabel.Foreground = Brushes.Green;

                    PasswordTextBox.BorderBrush = Brushes.Green;
                    Password2CheckTextBox.BorderBrush = Brushes.Green;

                    UserUsername.IsReadOnly = false;
                    //UserLogin.IsReadOnly = false;

                    UserUsername.BorderThickness = new Thickness(2);
                    UserUsername.BorderBrush = Brushes.Blue;
                    //UserLogin.BorderThickness = new Thickness(2);
                    //UserLogin.BorderBrush = Brushes.Blue;

                    SaveChanges.Visibility = Visibility.Visible;
                }
                else
                {
                    ErrorLabel.Content = "Wrong user password!";
                    ErrorLabel.Foreground = Brushes.Red;

                    PasswordTextBox.BorderBrush = Brushes.Red;
                    Password2CheckTextBox.BorderBrush = Brushes.Red;

                    PasswordTextBox.Text = "";
                    Password2CheckTextBox.Text = "";
                }
            }
            else
            {
                if (PasswordTextBox.Text == user.Password)
                {
                    PasswordTextBox.IsReadOnly = true;
                    Password2CheckTextBox.IsReadOnly = true;
                    ErrorLabel.Content = "Success";
                    ErrorLabel.Foreground = Brushes.Green;

                    PasswordTextBox.BorderBrush = Brushes.Green;
                    Password2CheckTextBox.BorderBrush = Brushes.Green;
                    //
                    User.currentUser.Password = Password2CheckTextBox.Text;
                }
                else
                {
                    ErrorLabel.Content = "Wrong user password!";
                    ErrorLabel.Foreground = Brushes.Red;

                    PasswordTextBox.BorderBrush = Brushes.Red;
                    Password2CheckTextBox.BorderBrush = Brushes.Red;

                    PasswordTextBox.Text = "";
                    Password2CheckTextBox.Text = "";
                }
            }

        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            user.Username = UserUsername.Text;
            //user.Login = UserLogin.Text;
            var page = new AccountSettings();
            NavigationService.Navigate(page);
        }

        private void ChangeUserPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                user.AvatarLink = openDialog.FileName;
            }
            var page = new AccountSettings();
            NavigationService.Navigate(page);
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";
            CheckPasswordStackPanel.Visibility = Visibility.Visible;

            PasswordTextBox.IsReadOnly = false;
            Password2CheckTextBox.IsReadOnly = false;

            PasswordTextBox.BorderThickness = new Thickness(2);
            PasswordTextBox.BorderBrush = Brushes.Blue;
            Password2CheckTextBox.BorderThickness = new Thickness(2);
            Password2CheckTextBox.BorderBrush = Brushes.Blue;

            Password1.Content = "Enter old password";
            Password2.Content = "Enter new password";
            CheckForCorrectPasswordTextBlock.Text = "Change password";
        }
    }
}
