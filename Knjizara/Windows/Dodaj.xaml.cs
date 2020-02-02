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
    /// Interaction logic for Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Window
    {
        public Dodaj()
        {
            InitializeComponent();
            clanTab.DataContext = new Clan();
            knjigaTab.DataContext = new Knjiga();
        }


        public void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (clanTab.IsSelected)
                {
                    ugClan.BindingGroup.CommitEdit();
                    DataContext = clanTab.DataContext;
                    this.DialogResult = true;
                    this.Close();   
                }

            if (knjigaTab.IsSelected )
                {
                    ugKnjiga.BindingGroup.CommitEdit();
                    DataContext = knjigaTab.DataContext;
                    this.DialogResult = true;
                    this.Close();
                }
        }


        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
