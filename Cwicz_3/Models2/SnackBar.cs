using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class SnackBar
    {
        public SnackBar()
        {
            StaffBar = new HashSet<StaffBar>();
        }

        public int IdSnackBar { get; set; }
        public int IdCinema { get; set; }
        public string Drinks { get; set; }
        public int DrinksPrice { get; set; }
        public string Meals { get; set; }
        public int MealsPrice { get; set; }

        public virtual Cinema IdCinemaNavigation { get; set; }
        public virtual ICollection<StaffBar> StaffBar { get; set; }
    }
}
