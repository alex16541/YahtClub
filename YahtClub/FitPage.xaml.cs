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
    /// Логика взаимодействия для FitPage.xaml
    /// </summary>
    public partial class FitPage : Page
    {
        public FitPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnBoats_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BoatsPage());
        }

        private void btnAccessory_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
