using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjizara.Klase
{
    public class Iznajmljivanje
    {
        public int ID { get; set; }
        public Clan iznajmljenClan { get; set; }
        public List<Knjiga> iznajmljeneKnjige { get; set; } = new List<Knjiga>();
        public DateTime kadIznajmljena { get; set; } = DateTime.Now;
        public DateTime? kadVracena { get; set; }
        public Iznajmljivanje() { }
        public Iznajmljivanje(Clan c, List<Knjiga> sveKnjige, int RV)
        {
            iznajmljenClan = c;
            iznajmljeneKnjige.AddRange(sveKnjige);
        }

    }
}
