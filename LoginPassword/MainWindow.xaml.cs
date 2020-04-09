using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using LoginPassword.Windows;

namespace LoginPassword
{
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            var saver = new Saver();
            var Users_List_DB = saver.LOAD_USER();
            user = new User(Login: Text_button.Text, Password: Password_button.Password);
            if (Users_List_DB.CheckForCorrectUserAndPassword(user))
            {
                HasErrorLabel.Foreground = Brushes.Green;
                HasErrorLabel.Text = "Success enter";
                User.currentUser = Users_List_DB.GetCurrentUser(user);

                AppWidnow appWidnow = new AppWidnow();
                this.Hide();
                appWidnow.ShowDialog();
                this.Show();
            }
            else
            {
                HasErrorLabel.Foreground = Brushes.Red;
                HasErrorLabel.Text = "This user dosen't exist";
            }
        }
        private void Register_TextDown_Event(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            this.Hide();
            registration.ShowDialog();
            this.Show();
        }
    }
}
