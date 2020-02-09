using Knjizara.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjizara.Klase
{

    public class Istorija
    {
        public ObservableCollection<Iznajmljivanje> istorija { get; set; } = new ObservableCollection<Iznajmljivanje>();
    }

}
