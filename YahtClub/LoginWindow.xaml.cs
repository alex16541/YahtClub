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
using System.Windows.Threading;
using System.Data.Entity;


namespace YahtClub
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private int passedLogin { get; set; }
        private int seconds { get; set; }
        private int secondsLeft { get; set; }
        DispatcherTimer timer = new DispatcherTimer();
        Entities db;
        public LoginWindow()
        {
            InitializeComponent();
            db = new Entities();
            db.Users.Load();
            this.Top = (1080 - this.Height) / 2;
            this.Left = (1920 - this.Width) / 2;
            passedLogin = 0;
            seconds = 15;
            timer.Tick += dispatcherTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(!timer.IsEnabled)
            {
                var user = db.Users.Where(u => u.login == tbLogin.Text).FirstOrDefault();
                if (user != null)
                {
                    if(!user.is_banned)
                    {
                        DateTime date = user.last_entry.Value.Date;
                        date = date.AddDays(31);

                        if (date > DateTime.Now)
                        {
                            if (user.password == pbPassword.Password)
                            {
                                MessageBox.Show($"Добро пожаловать {user.login}", "Здравствуйте!", MessageBoxButton.OK, MessageBoxImage.Information);
                                passedLogin = 0;
                                user.last_entry = DateTime.Now;
                                db.SaveChanges();
                                navigateThis(new MainWindow { Login = tbLogin.Text });
                            }
                        }
                    }    
                    else MessageBox.Show("Этот аккаунт заблокирован.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Вы ввели не верный логин или пароль. Пожалуйста проверьте ещё раз введенные данные.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    passedLogin++;
                    if (passedLogin == 3)
                    {
                        MessageBox.Show($"Вы заблокированы на {seconds} секунд.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        secondsLeft = seconds;
                        timer.Start();
                        seconds += 20;
                    }
                }
            }
            else MessageBox.Show($"Вы заблокированы на {secondsLeft} секунд.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            if (secondsLeft == 0)  timer.Stop();
        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow window = new RegistrationWindow();
            window.ShowDialog();
        }
        private void navigateThis(Window window)
        {
            window.Show();
            db.Dispose();
            this.Close();
        }
    }
}
