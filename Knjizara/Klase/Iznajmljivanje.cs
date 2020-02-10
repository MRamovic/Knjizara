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
       public Clan iznajmljenClan { get; set; } = new Clan();
       public List<Knjiga> iznajmljeneKnjige { get; set; } = new List<Knjiga>();
       public DateTime kadIznajmljena { get; set; } = DateTime.Now;
       public TimeSpan rokVracanja { get; set; }
       public DateTime kadVracena { get; set; }
        public Iznajmljivanje() { }
         public Iznajmljivanje(Clan c,List<Knjiga> sveKnjige,int RV) 
        {
            iznajmljenClan = c;
            iznajmljeneKnjige.AddRange(sveKnjige);
            rokVracanja = new TimeSpan(RV, 0, 0, 0);
        }

        public Iznajmljivanje (List<Knjiga> sveKnjige)
        {
            iznajmljeneKnjige = sveKnjige;
        }

    }
}
