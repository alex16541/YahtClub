﻿using System;
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
    public partial class BoatsPage : Page
    {
        Entities db = new Entities();
        public BoatsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.Boats.Load();
            dgBoats.ItemsSource = db.Boats.ToList();
            dgBoats.SelectedValuePath = "Model";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (new BoatAddWindow(db){ isEditable = true, boatModel = dgBoats.SelectedValue.ToString() }.ShowDialog() == true)
            {
                dgRefresh();
            }
        }

        private void btnDelate_Click(object sender, RoutedEventArgs e)
        {
            var boat = db.Boats.Where(b => b.Model == dgBoats.SelectedValue.ToString()).FirstOrDefault();
            if (MessageBox.Show(
                "Вы точно хотите удалить данную модель судна?",
                "Внимание!",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question
                ) == MessageBoxResult.Yes)
            {
                db.Boats.Remove(boat);
                db.SaveChanges();
                dgRefresh();
            }
        }

        private void btnAddNewBoat_Click(object sender, RoutedEventArgs e)
        {
            if (new BoatAddWindow(db).ShowDialog() == true)
            {
                dgRefresh();
            }
        }

        private void dgRefresh()
        {

            dgBoats.ItemsSource = db.Boats.ToList();
            dgBoats.Items.Refresh();
        }
    }
}
