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
    /// Логика взаимодействия для AccessoryAddPage.xaml
    /// </summary>
    public partial class AccessoryAddPage : Window
    {

        public Entities db { get; set; }
        Accessory acc = new Accessory();
        public string accName = "";
        public bool isEditable = false;
        public AccessoryAddPage(Entities db)
        {
            InitializeComponent();
            this.db = db;
            this.db.Partner.Load();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Top = (1080 - this.Height) / 2;
            this.Left = (1920 - this.Width) / 2;

            cbPartner.ItemsSource = db.Partner.ToList();
            cbPartner.DisplayMemberPath = "Name";
            cbPartner.SelectedValuePath = "Partner_ID";

            if (isEditable)
            {
                acc = db.Accessory.Where(a => a.AccName == accName).FirstOrDefault();
                tbName.Text = acc.AccName;
                tbDiscription.Text = acc.DescriptionOfAccessory;
                tbPrice.Text = acc.Price.ToString();
                tbVat.Text = acc.VAT;
                tbCount.Text = acc.Inventory.ToString();
                tbOrderLevel.Text = acc.OrderLevel.ToString();
                tbOrderBatch.Text = acc.OrderBatch.ToString();
                cbPartner.SelectedValue = acc.Partner_ID;
                tbName.IsEnabled = false;
                btnAdd.Content = "Edit";
                Title = "Edit accessory";
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

            if (tbPrice.Text != "" && tbName.Text != "" && tbOrderBatch.Text != "" && tbDiscription.Text != ""
                && tbOrderLevel.Text != "" && tbVat.Text != "" && tbCount.Text != "")
            {
                try
                {
                    acc.AccName = tbName.Text;
                    acc.DescriptionOfAccessory = tbDiscription.Text;
                    acc.Price = decimal.Parse(tbPrice.Text);
                    acc.VAT = tbVat.Text;
                    acc.Inventory = int.Parse(tbCount.Text);
                    acc.OrderLevel = int.Parse(tbOrderLevel.Text);
                    acc.OrderBatch = int.Parse(tbOrderBatch.Text);
                    acc.Partner_ID = int.Parse(cbPartner.SelectedValue.ToString());
                }
                catch (Exception exep)
                {
                    MessageBox.Show(exep.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (isEditable)
                {
                    
                }
                else
                {
                    if (db.Accessory.Where(a => a.AccName == accName).FirstOrDefault() == null)
                    {
                        db.Accessory.Add(acc);
                    }
                    else MessageBox.Show("Судно с такой моделью уже существует.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                db.SaveChanges();
                DialogResult = true;
                this.Close();
            }
            else MessageBox.Show("Все поля должны быть заполнены.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void btnReg_Copy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
