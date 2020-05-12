using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Staff
    {
        public Staff()
        {
            StaffBar = new HashSet<StaffBar>();
            StaffHall = new HashSet<StaffHall>();
        }

        public int IdStaff { get; set; }
        public int IdCinema { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public int IdProfession { get; set; }

        public virtual ICollection<StaffBar> StaffBar { get; set; }
        public virtual ICollection<StaffHall> StaffHall { get; set; }
    }
}
