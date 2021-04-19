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

namespace YahtClub
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        Entities db;
        public RegistrationWindow()
        {
            InitializeComponent();
            db = new Entities();
            this.Top = (1080 - this.Height) / 2;
            this.Left = (1920 - this.Width) / 2;
        }

        private void btnReg_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (db.Users.Where(u => u.login == tbLogin.Text).FirstOrDefault() == null)
            {
                if (pbPassword.Password != "" && tbLogin.Text != "")
                {
                    if(pbPassword.Password == pbPassword_Copy.Password)
                    {
                        Users user = new Users();
                        user.login = tbLogin.Text;
                        user.password = pbPassword.Password;
                        user.role_id = 2;
                        user.last_entry = DateTime.Now;
                        db.Users.Add(user);
                        db.SaveChanges();
                        DialogResult = true;
                        this.Close();
                    }
                    else MessageBox.Show("Пароль не совпадает", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else MessageBox.Show("Поля логина и пароля не должны быть пустыми.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else MessageBox.Show("Пользователь с таким логином уже существует.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
