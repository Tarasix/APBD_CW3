using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class FilmCustom
    {
        public int IdFilm { get; set; }
        public int IdCustomer { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public int Price { get; set; }

        public virtual Customers IdCustomerNavigation { get; set; }
        public virtual Films IdFilmNavigation { get; set; }
    }
}
