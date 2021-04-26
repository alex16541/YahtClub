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
    /// Логика взаимодействия для BoatsAndAccAddPage.xaml
    /// </summary>
    public partial class BoatsAndAccAddPage : Window
    {
        public Entities db { get; set; }
        Fit fit = new Fit();
        public int fitId;
        public bool isEditable = false;
        public BoatsAndAccAddPage(Entities db)
        {
            InitializeComponent();
            this.db = db;
            Top = (1080 - this.Height) / 2;
            Left = (1920 - this.Width) / 2;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbBoat.ItemsSource = db.Boats.ToList();
            cbBoat.SelectedValuePath = "boat_ID";
            cbBoat.DisplayMemberPath = "Model";
            cbAccessory.ItemsSource = db.Accessory.ToList();
            cbAccessory.SelectedValuePath = "Accessory_ID";
            cbAccessory.DisplayMemberPath = "AccName";

            if (isEditable)
            {
                fit = db.Fit.Where(f => f.Fit_ID == fitId).FirstOrDefault();
                cbBoat.SelectedValue = fit.Boat_ID;
                cbAccessory.SelectedValue = fit.Accessory_ID;
                btnAdd.Content = "Edit";
                Title = "Edit boat";
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbBoat.Text != "" && cbAccessory.Text != "")
            {
                try
                {
                    fit.Boat_ID = int.Parse(cbBoat.SelectedValue.ToString());
                    fit.Accessory_ID = int.Parse(cbAccessory.SelectedValue.ToString());
                }
                catch (Exception exep)
                {
                    MessageBox.Show(exep.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (db.Fit.Where(f => f.Boat_ID == int.Parse(cbBoat.SelectedValue.ToString()) && f.Accessory_ID == int.Parse(cbAccessory.SelectedValue.ToString())).FirstOrDefault() == null)
                {
                    db.Fit.Add(fit);
                }
                else MessageBox.Show("Такая запсь уже существует.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);

                db.SaveChanges();
                DialogResult = true;
                this.Close();
            }
            else MessageBox.Show("Все поля должны быть заполнены.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
