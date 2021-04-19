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
    public partial class UserAddWindow : Window
    {
        public Entities db { get; set; }
        Users user = new Users();
        public string userLogin = "";
        public bool isEditable = false;
        public UserAddWindow(Entities db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Top = (1080 - this.Height) / 2;
            this.Left = (1920 - this.Width) / 2;
            cbRole.ItemsSource = db.Roles.ToList();
            cbRole.DisplayMemberPath = "role";
            cbRole.SelectedValuePath = "id";
            if(isEditable)
            {
                user = db.Users.Where(u => u.login == userLogin).FirstOrDefault();
                cbRole.SelectedIndex = user.role_id-1;
                tbLogin.Text = user.login;
                pbPassword.Password = user.password;
                cbIsBanned.IsChecked = user.is_banned;
                tbLogin.IsEnabled = false;
                btnAdd.Content = "Edit";
                Title = "Edit user";
                cbIsBanned.Visibility = Visibility.Visible;
            }
            else
            {
                cbRole.SelectedIndex = 0;
            }
        }

        private void btnReg_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password != "" && tbLogin.Text != "" && cbRole.Text != "")
            {
                user.login = tbLogin.Text;
                user.password = pbPassword.Password;
                user.role_id = (int)cbRole.SelectedValue;
                if (isEditable)
                {
                    user.is_banned = (bool)cbIsBanned.IsChecked;
                }
                else
                {
                    if (db.Users.Where(u => u.login == tbLogin.Text).FirstOrDefault() == null)
                    {
                        user.last_entry = DateTime.Now;
                        db.Users.Add(user);
                    }
                    else MessageBox.Show("Пользователь с таким логином уже существует.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                db.SaveChanges();
                DialogResult = true;
                this.Close();
            }
            else MessageBox.Show("Поля логина и пароля не должны быть пустыми.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            
        }

        
    }
}
