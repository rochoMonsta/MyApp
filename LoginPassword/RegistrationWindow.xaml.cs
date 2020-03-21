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
using LoginPassword.Windows;

namespace LoginPassword
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void PasswordBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Password_button.Password = "";
        }

        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Text_button.Text = "";
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            var saver = new Saver();
            var Users_List_DB = saver.LOAD_USER();
            var user = new User(Login: Text_button.Text, Password: Password_button.Password);
            if ((user.Login == "Username" || user.Login == null || user.Login == "") || (user.Password == "Password" || user.Password == null || user.Password == ""))
            {
                HasErrorLabel.Foreground = Brushes.Red;
                HasErrorLabel.Text = "Enter some Login/Password";
            }
            else
            {
                if (Users_List_DB.ListContains(user))
                {
                    HasErrorLabel.Foreground = Brushes.Red;
                    HasErrorLabel.Text = "This user is already registered";
                }
                else
                {
                    HasErrorLabel.Foreground = Brushes.Green;
                    HasErrorLabel.Text = "Success";
                    Users_List_DB.AddNewUser(user);
                    saver.SAVE_USER(Users_List_DB);
                    User.currentUser = Users_List_DB.GetCurrentUser(user);

                    AppWidnow appWidnow = new AppWidnow();
                    this.Hide();
                    appWidnow.ShowDialog();
                    this.Show();
                }
            }
        }
    }
}
