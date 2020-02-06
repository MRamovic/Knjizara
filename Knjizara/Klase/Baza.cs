using Knjizara.Klase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjizara
{
    
    public class Baza : DbContext
    {
        public DbSet<Clan> dbClanovi { get; set; }
        public DbSet<Knjiga> dbKnjige { get; set; }
        public DbSet<Zaposlen> dbZaposleni { get; set; }
        public DbSet<Iznajmljivanje> dbIznajmljeno { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Clan>().HasKey(p => p.ID);      //PK za ID korisnika
            modelBuilder.Entity<Knjiga>().HasKey(k => k.ISBN);  //PK za ISBN knjige
            modelBuilder.Entity<Zaposlen>().HasKey(z => z.ID);


        }
    }
}
