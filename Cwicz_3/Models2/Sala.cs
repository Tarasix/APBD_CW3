using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Sala
    {
        public Sala()
        {
            Rezerwacja = new HashSet<Rezerwacja>();
        }

        public int IdSala { get; set; }
        public string Typ { get; set; }

        public virtual ICollection<Rezerwacja> Rezerwacja { get; set; }
    }
}
