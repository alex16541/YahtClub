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
using System.Data.Entity;

namespace YahtClub
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        Entities db = new Entities();
        public UsersPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.Users.Load();
            db.Roles.Load();
            dgUsers.ItemsSource = db.Users.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelate_Click(object sender, RoutedEventArgs e)
        {
            var user = db.Users.Where(u => u.id == dgUsers.SelectedIndex + 1).FirstOrDefault();
            if (user.is_banned)
            {
                
                if (MessageBox.Show("Вы точно хотите удалить этого пользователя?", "Внимание!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
            else MessageBox.Show("Этот пользователь не заблокирован. Удаление невозможно.", "Внимани", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
