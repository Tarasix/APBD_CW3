using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class StaffBar
    {
        public int IdStaffBar { get; set; }
        public int IdSnackBar { get; set; }
        public int IdStaff { get; set; }

        public virtual SnackBar IdSnackBarNavigation { get; set; }
        public virtual Staff IdStaffNavigation { get; set; }
    }
}
