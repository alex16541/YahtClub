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
using System.Data.Entity;

namespace YahtClub
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public string Login { get; set; }
        Entities db = new Entities();
        public ChangePasswordWindow()
        {
            InitializeComponent();
            this.Top = (1080 - this.Height) / 2;
            this.Left = (1920 - this.Width) / 2;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password != "")
            {
                if (pbPassword.Password == pbPassword_Copy.Password)
                {
                    var user = db.Users.Where(u => u.login == Login).FirstOrDefault();
                    if (pbPassword.Password != user.password)
                    {
                        user.password = pbPassword.Password;
                        user.pass_change_date = DateTime.Now;
                        db.SaveChanges();
                        db.Dispose();
                        DialogResult = true;
                        this.Close();
                    }
                }
                else MessageBox.Show("Пароли не совпадают.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else MessageBox.Show("Ведите пароль.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
