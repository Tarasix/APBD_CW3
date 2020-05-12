using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Customers
    {
        public Customers()
        {
            FilmCustom = new HashSet<FilmCustom>();
        }

        public int IdCustomer { get; set; }
        public int Phone { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<FilmCustom> FilmCustom { get; set; }
    }
}
