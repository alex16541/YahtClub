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
    /// Логика взаимодействия для AccessoryPage.xaml
    /// </summary>
    public partial class AccessoryPage : Page
    {
        Entities db = new Entities();
        public AccessoryPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.Accessory.Load();
            dgAcc.ItemsSource = db.Accessory.ToList();
            dgAcc.SelectedValuePath = "AccName";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (new AccessoryAddPage(db) { isEditable = true, accName = dgAcc.SelectedValue.ToString() }.ShowDialog() == true)
            {
                dgRefresh();
            }
        }

        private void btnDelate_Click(object sender, RoutedEventArgs e)
        {
            var acc = db.Accessory.Where(a => a.AccName== dgAcc.SelectedValue.ToString()).FirstOrDefault();
            if (MessageBox.Show(
                "Вы точно хотите удалить данную этот аксесуар?",
                "Внимание!",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question
                ) == MessageBoxResult.Yes)
            {
                db.Accessory.Remove(acc);
                db.SaveChanges();
                dgRefresh();
            }
        }

        private void dgRefresh()
        {

            dgAcc.ItemsSource = db.Accessory.ToList();
            dgAcc.Items.Refresh();
        }

        private void btnAddNewAcc_Click(object sender, RoutedEventArgs e)
        {
            if (new AccessoryAddPage(db).ShowDialog() == true)
            {
                dgRefresh();
            }
        }
    }
}
