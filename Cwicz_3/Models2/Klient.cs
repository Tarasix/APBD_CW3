using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Klient
    {
        public Klient()
        {
            Rezerwacja = new HashSet<Rezerwacja>();
        }

        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Rezerwacja> Rezerwacja { get; set; }
    }
}
