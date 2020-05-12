using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Opinia
    {
        public int IdOpinia { get; set; }
        public int? Ocena { get; set; }
        public string Recenzja { get; set; }
        public int IdRezerwacja { get; set; }

        public virtual Rezerwacja IdRezerwacjaNavigation { get; set; }
    }
}
