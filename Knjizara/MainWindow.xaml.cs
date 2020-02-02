using Knjizara.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

namespace Knjizara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Baza NB = new Baza();

        private string pretraga;    

        public string Pretraga
        {
            get => pretraga;
            set
            {
                pretraga = value;

                NB = new Baza();

                if (string.IsNullOrEmpty(pretraga) || string.IsNullOrWhiteSpace(pretraga))
                {
                    dgClan.ItemsSource = NB.dbClanovi.ToList();
                    dgKnjiga.ItemsSource = NB.dbKnjige.ToList();
                }
                else
                {
                    if (ClanTab.IsSelected)

                    {
                        dgClan.ItemsSource = NB.dbClanovi.Where(c => c.Ime.ToLower().Contains(pretraga.ToLower()) ||
                                                                     c.Prezime.ToLower().Contains(pretraga.ToLower()) ||
                                                                     c.Kontakt.ToLower().Contains(pretraga.ToLower())).ToList();
                    }

                    else if (KnjigaTab.IsSelected)
                    {
                        dgKnjiga.ItemsSource = NB.dbKnjige.Where(v => v.Naziv.ToLower().Contains(pretraga.ToLower()) ||
                                                                      v.Autor.ToLower().Contains(pretraga.ToLower()) ||
                                                                      v.ISBN.ToLower().Contains(pretraga.ToLower()) ||
                                                                      v.GodIzdavanja.ToLower().Contains(pretraga.ToLower())).ToList();
                    }
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            NB.dbClanovi.ToList();
            NB.dbKnjige.ToList();
            NB.SaveChanges();  //Cuvamo podatke u bazu

            dgClan.ItemsSource = NB.dbClanovi.Local;
            dgKnjiga.ItemsSource = NB.dbKnjige.Local;

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodaj novoDodaj = new Dodaj();
            novoDodaj.Owner = this;

            if (novoDodaj.ShowDialog() == true)
            {

                if (novoDodaj.DataContext is Clan c)
                    NB.dbClanovi.Add(c);

                else if (novoDodaj.DataContext is Knjiga k)
                    NB.dbKnjige.Add(k);
                    NB.SaveChanges();
            }

        }


        private void dgClan_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clanovi noviClan = new Clanovi();
            noviClan.Owner = this;
            noviClan.DataContext = dgClan.SelectedItem;

            if (noviClan.ShowDialog() == true)
            {
                NB.SaveChanges();
                NB = new Baza();
                dgClan.ItemsSource = NB.dbClanovi.ToList();
            }
        }

        private void dgKnjiga_MouseDoubleClick(object sender, MouseButtonEventArgs e)  
        {
            Knjige novaKnjiga = new Knjige();
            novaKnjiga.Owner = this;
            novaKnjiga.DataContext = dgKnjiga.SelectedItem;

            if (novaKnjiga.ShowDialog() == true)
            {
                NB.SaveChanges();
                NB = new Baza();
                dgKnjiga.ItemsSource = NB.dbKnjige.ToList();
            }
        }


        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Izmeni_Click(object sender, RoutedEventArgs e)    //Izmena postojecih korisnika i knjiga
        {

            if (dgKnjiga.SelectedItem != null)
            {
                Knjige nk = new Knjige();
                nk.Owner = this;
                nk.DataContext = dgKnjiga.SelectedItem;
                if (nk.ShowDialog() == true)
                NB.SaveChanges();
            } 
            else if  (dgClan.SelectedItem != null)
             {
                ClanProfil  nc = new ClanProfil();
                nc.Owner = this;
                nc.DataContext = dgClan.SelectedItem;
                if (nc.ShowDialog() == true)
                NB.SaveChanges();
             }
        }


        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgClan.SelectedItem !=null)
            {
                NB.dbClanovi.Remove(dgClan.SelectedItem as Clan);
                NB.SaveChanges();
            }

            else if (dgKnjiga.SelectedItem !=null)
            {
                NB.dbKnjige.Remove(dgKnjiga.SelectedItem as Knjiga);
                NB.SaveChanges();

            }
        }
    }
}
