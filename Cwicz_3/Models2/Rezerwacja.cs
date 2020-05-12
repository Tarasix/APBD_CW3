using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Rezerwacja
    {
        public Rezerwacja()
        {
            MenuRezerwacja = new HashSet<MenuRezerwacja>();
            Opinia = new HashSet<Opinia>();
        }

        public int IdRezerwacja { get; set; }
        public DateTime CzasRozp { get; set; }
        public DateTime CzasZakon { get; set; }
        public int NumStolika { get; set; }
        public int IdKlient { get; set; }
        public int IdPracownik { get; set; }
        public int IdSala { get; set; }

        public virtual Klient IdKlientNavigation { get; set; }
        public virtual Pracownicy IdPracownikNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
        public virtual ICollection<MenuRezerwacja> MenuRezerwacja { get; set; }
        public virtual ICollection<Opinia> Opinia { get; set; }
    }
}
