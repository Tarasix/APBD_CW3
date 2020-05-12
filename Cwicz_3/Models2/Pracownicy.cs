using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Pracownicy
    {
        public Pracownicy()
        {
            Gotowanie = new HashSet<Gotowanie>();
            Rezerwacja = new HashSet<Rezerwacja>();
        }

        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Pencja { get; set; }
        public int? Prowizja { get; set; }
        public DateTime DataZatrud { get; set; }
        public int IdStanowisko { get; set; }

        public virtual Stanowisko IdStanowiskoNavigation { get; set; }
        public virtual ICollection<Gotowanie> Gotowanie { get; set; }
        public virtual ICollection<Rezerwacja> Rezerwacja { get; set; }
    }
}
