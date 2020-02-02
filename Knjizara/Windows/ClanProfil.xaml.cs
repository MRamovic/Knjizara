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
    /// Interaction logic for ClanProfil.xaml
    /// </summary>
    public partial class ClanProfil : Window
    {
        public ClanProfil()
        {
            InitializeComponent();    
        }       

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.BindingGroup.CommitEdit();
            this.DialogResult = true;
            this.Close();     
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
