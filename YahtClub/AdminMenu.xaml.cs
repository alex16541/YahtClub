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

namespace YahtClub
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        public MainWindow owner { get; set; }
        Entities db = new Entities();
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (db.Users.Where(u => u.login == owner.Login).FirstOrDefault().date_pass_change.Value.AddDays(15) <= DateTime.Now)
            {
                if (new ChangePasswordWindow { Login = owner.Login }.ShowDialog() == true)
                    MessageBox.Show("Пароль успешно изменён", "Пароль", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
        
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            owner.Close();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersPage());
        }

    }
}
