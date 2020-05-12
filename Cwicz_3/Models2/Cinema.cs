using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Cinema
    {
        public Cinema()
        {
            Films = new HashSet<Films>();
            Hall = new HashSet<Hall>();
            SnackBar = new HashSet<SnackBar>();
        }

        public int IdCinema { get; set; }
        public int Phone { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        public virtual ICollection<Films> Films { get; set; }
        public virtual ICollection<Hall> Hall { get; set; }
        public virtual ICollection<SnackBar> SnackBar { get; set; }
    }
}
