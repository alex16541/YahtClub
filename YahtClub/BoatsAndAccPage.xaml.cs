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
    /// Логика взаимодействия для BoatsAndAccPage.xaml
    /// </summary>
    public partial class BoatsAndAccPage : Page
    {
        Entities db = new Entities();
        public BoatsAndAccPage()
        {
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.Boats.Load();
            db.Fit.Load();
            db.Accessory.Load();
            dgFit.ItemsSource = db.Fit.ToList();
            dgFit.SelectedValuePath = "Fit_ID";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (new BoatsAndAccAddPage(db) { isEditable = true, fitId = dgFit.SelectedValue.ToString() }.ShowDialog() == true)
            {
                dgRefresh();
            }
        }

        private void btnDelate_Click(object sender, RoutedEventArgs e)
        {
            var fit = db.Fit.Where(f => f.Fit_ID == int.Parse(dgFit.SelectedValue.ToString())).FirstOrDefault();
            if (MessageBox.Show(
                "Вы точно хотите удалить эту запись?",
                "Внимание!",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question
                ) == MessageBoxResult.Yes)
            {
                db.Fit.Remove(fit);
                db.SaveChanges();
                dgRefresh();
            }
        }

        private void btnAddNewFit_Click(object sender, RoutedEventArgs e)
        {
            if (new BoatAddWindow(db).ShowDialog() == true)
            {
                dgRefresh();
            }
        }

        private void dgRefresh()
        {

            dgFit.ItemsSource = db.Fit.ToList();
            dgFit.Items.Refresh();
        }
    }
}
