using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Hall
    {
        public Hall()
        {
            StaffHall = new HashSet<StaffHall>();
        }

        public int IdHall { get; set; }
        public int IdCinema { get; set; }
        public int Capacity { get; set; }
        public int RowCount { get; set; }
        public string Name { get; set; }

        public virtual Cinema IdCinemaNavigation { get; set; }
        public virtual ICollection<StaffHall> StaffHall { get; set; }
    }
}
