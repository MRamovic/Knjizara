using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjizara
{
    public class Clan
    {
        public int ID { get; set; } 
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kontakt { get; set; }
        public string Email { get; set; }


        public Clan() { }

        public Clan(string i, string p, string k)
        {
            Ime = i;
            Prezime = p;
            Kontakt = k;
        }

        public Clan(string i, string p, string k,string e)
        {
            Ime = i;
            Prezime = p;
            Kontakt = k;
            Email = e;
        }
        public override string ToString() => $"{Ime} {Prezime }";
        
    }
}
