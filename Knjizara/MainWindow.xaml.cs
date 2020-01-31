using Knjizara.Windows;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            NB.dbClanovi.ToList();
            NB.dbKnjige.ToList();
            //NB.dbClanovi.Add(new Clan("Mirza", "Ramovic", "066"));
            //NB.dbClanovi.Add(new Clan("Pera", "Peric", "063"));
            //NB.dbKnjige.Add(new Knjiga("Rad i mir", "Tolstoj", "1953","SAD1254522", 10));
            //NB.dbKnjige.Add(new Knjiga("Kockar", "Dostojevski", "1984","SKJ844578", 20));

           NB.SaveChanges();  //Cuvamo podatke u bazu

            dgClan.ItemsSource = NB.dbClanovi.Local;
            dgKnjiga.ItemsSource = NB.dbKnjige.Local;

        }


        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodaj novoDodaj = new Dodaj();
            novoDodaj.Visibility = Visibility.Visible;

        }
    }
}
