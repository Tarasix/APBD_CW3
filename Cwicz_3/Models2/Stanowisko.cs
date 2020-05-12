using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Stanowisko
    {
        public Stanowisko()
        {
            Pracownicy = new HashSet<Pracownicy>();
        }

        public int IdStanowisko { get; set; }
        public string NazwaStan { get; set; }

        public virtual ICollection<Pracownicy> Pracownicy { get; set; }
    }
}
