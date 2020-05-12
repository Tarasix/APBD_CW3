using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Placa1
    {
        public int IdPlaca { get; set; }
        public int? Placa { get; set; }
        public int? IdRezerwacja { get; set; }
        public int? IdMenuRez { get; set; }

        public virtual MenuRezerwacja IdMenuRezNavigation { get; set; }
    }
}
