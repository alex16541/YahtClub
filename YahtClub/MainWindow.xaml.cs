using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public string Login { get; set; }
        Entities db = new Entities();
        public MainWindow()
        {
            InitializeComponent();
            this.Top = (1080 - this.Height) / 2;
            this.Left = (1920 - this.Width) / 2;
        }

        private void NavigationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var role = db.Roles.Where(r => r.id == db.Users.Where(u => u.login == Login).FirstOrDefault().role_id).FirstOrDefault().title;
            switch (role)
            {
                case "A": this.NavigationService.Navigate(new AdminMenu { owner = this }); break;
                case "C": this.NavigationService.Navigate(new MainMenu  { owner = this }); break;
                default:
                    break;
            }
        }
    }
}
