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
        public Baza NBK = new Baza();
        Knjiga NK = new Knjiga();
        Istorija ist = new Istorija();
        Iznajmljivanje r = new Iznajmljivanje();
        


        public Clanovi()
        {
            InitializeComponent();

            NBK.dbKnjige.ToList();
            NBK.dbClanovi.ToList();
            dgIznajmiti.ItemsSource = NBK.dbKnjige.ToList();

            dgIznajmljeno.ItemsSource = r.iznajmljeneKnjige;
            Clan test = DataContext as Clan;
            List<Knjiga> tK = new List<Knjiga>();
            NBK.dbIznajmljeno.Where(izm => izm.kadVracena == null && izm.iznajmljenClan.Equals(test))
                .ToList().ForEach(izn => tK.AddRange(izn.iznajmljeneKnjige));

            dgTrenutnoZ.ItemsSource = tK;

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
                NBK.SaveChanges ();
                this.Close();
            }
  

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {

            if (dgIznajmiti.SelectedItem != null)
            {
                if (!dgIznajmljeno.Items.Contains(dgIznajmiti.SelectedItem))
                {
                    r.iznajmljeneKnjige.Add(dgIznajmiti.SelectedItem as Knjiga);
                    dgIznajmljeno.ItemsSource = null;
                    dgIznajmljeno.ItemsSource = r.iznajmljeneKnjige;
                }
                else
                    MessageBox.Show("Knjiga je dodata!");
            }
            else
                MessageBox.Show("Izaberite knjigu!");

        }

        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgIznajmljeno_LayoutUpdated(object sender, EventArgs e)
        {

        }
    }
}
