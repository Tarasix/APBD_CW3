using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class MenuJedzenia
    {
        public MenuJedzenia()
        {
            MenuRezerwacja = new HashSet<MenuRezerwacja>();
        }

        public int IdMenuJedz { get; set; }
        public string Typ { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public virtual ICollection<MenuRezerwacja> MenuRezerwacja { get; set; }
    }
}
