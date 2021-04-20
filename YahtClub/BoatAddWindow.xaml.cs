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
    public partial class BoatAddWindow : Window
    {
        public Entities db { get; set; }
        Boats boat = new Boats();
        public string boatModel = "";
        public bool isEditable = false;
        public BoatAddWindow(Entities db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Top = (1080 - this.Height) / 2;
            this.Left = (1920 - this.Width) / 2;
            if(isEditable)
            {
                boat = db.Boats.Where(u => u.Model == boatModel).FirstOrDefault();
                tbPrice.Text = boat.BasePrice.ToString();
                tbColor.Text = boat.Colour;
                cbMast.IsChecked = boat.Mast;
                tbModel.IsEnabled = false;
                btnAdd.Content = "Edit";
                Title = "Edit boat";
                cbMast.Visibility = Visibility.Visible;
            }
        }

        private void btnReg_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (tbPrice.Text != "" && tbNoR.Text != "" && tbModel.Text != "" && tbColor.Text != ""
                && tbType.Text != "" && tbVat.Text != "" && tbWood.Text != "")
            {
                boat.Model = tbModel.Text;
                boat.Colour = tbColor.Text;
                boat.BasePrice = tbPrice.Text;
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
