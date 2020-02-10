using Knjizara.Klase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Istorija ist = new Istorija();
        Iznajmljivanje r = new Iznajmljivanje();
        


        public Clanovi()
        {
            InitializeComponent();
           
            NBK.dbKnjige.ToList();
            NBK.SaveChanges();
            dgIznajmiti.ItemsSource = NBK.dbKnjige.ToList();
            dgIznajmljeno.ItemsSource = r.iznajmljeneKnjige;
            dgTrenutnoZ.ItemsSource = NBK.dbIznajmljeno.ToList();
            
           
        }


        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }


        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if(infoTab.IsSelected)
            {
                this.BindingGroup.CommitEdit();
                this.DialogResult = true;
                this.Close();
            }
            if(iznajmiTab.IsSelected )
            {
                NBK.dbIznajmljeno.Add(new Iznajmljivanje(infoTab.DataContext as Clan, r.iznajmljeneKnjige, 7));
                
                
                
            }
            
            
            

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {

            if (dgIznajmiti.SelectedItem != null)
            {
                if (!dgIznajmljeno.Items.Contains(dgIznajmiti.SelectedItem))
                {
                    r.iznajmljeneKnjige.Add(dgIznajmiti.SelectedItem as Knjiga);
                }
                else
                    MessageBox.Show("Knjiga je dodata!");
            }
            else
                MessageBox.Show("Izaberite knjigu!");


           
            //if (dgIznajmiti.SelectedItem != null)
            //    if (!dgIznajmljeno.Items.Contains(dgIznajmiti.SelectedItem))
            //        r.iznajmljeneKnjige.Add(dgIznajmiti.SelectedItem as Knjiga);
            



            //NK = dgIznajmiti.SelectedItem as Knjiga;

            //(dgIznajmiti.SelectedItem as Knjiga).Kolicina -=1;
            //NBK.SaveChanges();
            //dgIznajmiti.ItemsSource = NBK.dbKnjige.Where(k => k.Kolicina != 0).ToList();

        }

        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgIznajmljeno_LayoutUpdated(object sender, EventArgs e)
        {

        }
    }
}
