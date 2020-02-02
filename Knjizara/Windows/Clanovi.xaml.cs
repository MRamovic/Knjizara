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

namespace Knjizara.Windows
{
    /// <summary>
    /// Interaction logic for Clanovi.xaml
    /// </summary>
    public partial class Clanovi : Window
    {
        Baza NBK = new Baza();
        Knjiga NK = new Knjiga();
        

        public Clanovi()
        {
            InitializeComponent();
            NBK.dbKnjige.ToList();
            NBK.SaveChanges();
            dgIznajmiti.ItemsSource = NBK.dbKnjige.Local;
        }


        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }


        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.BindingGroup.CommitEdit();
            this.DialogResult = true;
            this.Close();
            

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            // dgIznajmljeno.ItemsSource= dgIznajmljeno.SelectedItem;
            
            NK = dgIznajmiti.SelectedItem as Knjiga;
            (dgIznajmiti.SelectedItem as Knjiga).Kolicina -=1;
            NBK.SaveChanges();
            NBK.dbKnjige.Remove(dgIznajmiti.SelectedItem as Knjiga);
            
            

        }

        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
