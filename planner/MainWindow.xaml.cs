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

namespace planner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Reg_Click_1(object sender, RoutedEventArgs e)
        {
            string login = TextBloxLog1.Text.Trim();
            string pass = PassBloxLog.Password.Trim();

            if (login.Length < 4)
            {
                TextBloxLog1.ToolTip = "Это поле введено не корректно.";
                TextBloxLog1.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                PassBloxLog.ToolTip = "Это поле введено не корректно.";
                PassBloxLog.Background = Brushes.DarkRed;
            }
            else
            {
                TextBloxLog1.ToolTip = "";
                TextBloxLog1.Background = Brushes.Transparent;
                PassBloxLog.ToolTip = "";
                PassBloxLog.Background = Brushes.Transparent;

                MessageBox.Show("Добро пожаловать!");

                User user = new User(login, pass);

                db.Users.Add(user);
                db.SaveChanges();

                Second second = new Second();
                second.Show();
                Hide();
            }
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBloxLog1.Text.Trim();
            string pass = PassBloxLog.Password.Trim();

            if (login.Length < 4)
            {
                TextBloxLog1.ToolTip = "Это поле введено не корректно.";
                TextBloxLog1.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                PassBloxLog.ToolTip = "Это поле введено не корректно.";
                PassBloxLog.Background = Brushes.DarkRed;
            }
            else
            {
                TextBloxLog1.ToolTip = "";
                TextBloxLog1.Background = Brushes.Transparent;
                PassBloxLog.ToolTip = "";
                PassBloxLog.Background = Brushes.Transparent;

                User authUser = null;
                using (AppContext context = new AppContext())
                {
                    authUser = context.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MessageBox.Show("Добро пожаловать!");
                    Second second = new Second();
                    second.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Такого пользователя не существует");
            }
        }
    }
}
