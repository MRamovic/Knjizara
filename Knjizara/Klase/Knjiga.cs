using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjizara
{
    public class Knjiga
    {
        public string ISBN { get; set; }
        public string Naziv { get; set; }
        public string Autor { get; set; }
        public string GodIzdavanja { get; set; }
        public int Kolicina { get; set; }


        public Knjiga() { }

        public Knjiga( string n, string a, string g, string i, int k)
        { 
            Naziv = n;
            Autor = a;
            GodIzdavanja = g;
            ISBN = i;
            Kolicina = k;
        }

    }

  

}
