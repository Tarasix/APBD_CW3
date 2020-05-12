using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Gotowanie
    {
        public int IdGotowanie { get; set; }
        public int IdMenuRez { get; set; }
        public int IdPracownik { get; set; }

        public virtual MenuRezerwacja IdMenuRezNavigation { get; set; }
        public virtual Pracownicy IdPracownikNavigation { get; set; }
    }
}
