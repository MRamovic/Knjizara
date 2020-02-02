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
using System.Windows.Shapes;

namespace Knjizara.Windows
{
    /// <summary>
    /// Interaction logic for Knjige.xaml
    /// </summary>
    public partial class Knjige : Window
    {
        public Knjige()
        {
            InitializeComponent();
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
    }
}
