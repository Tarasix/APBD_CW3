using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class MenuRezerwacja
    {
        public MenuRezerwacja()
        {
            Gotowanie = new HashSet<Gotowanie>();
            Placa1 = new HashSet<Placa1>();
        }

        public int IdMenuRez { get; set; }
        public int IdRezerwacja { get; set; }
        public int IdMenuPicia { get; set; }
        public int IdMenuJedz { get; set; }

        public virtual MenuJedzenia IdMenuJedzNavigation { get; set; }
        public virtual MenuPicia IdMenuPiciaNavigation { get; set; }
        public virtual Rezerwacja IdRezerwacjaNavigation { get; set; }
        public virtual ICollection<Gotowanie> Gotowanie { get; set; }
        public virtual ICollection<Placa1> Placa1 { get; set; }
    }
}
