using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class StaffHall
    {
        public int IdStaffHall { get; set; }
        public int IdHall { get; set; }
        public int IdStaff { get; set; }

        public virtual Hall IdHallNavigation { get; set; }
        public virtual Staff IdStaffNavigation { get; set; }
    }
}
