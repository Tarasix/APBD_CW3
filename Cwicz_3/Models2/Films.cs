using System;
using System.Collections.Generic;

namespace Cwicz_3.Models2
{
    public partial class Films
    {
        public Films()
        {
            FilmCustom = new HashSet<FilmCustom>();
        }

        public int IdFilm { get; set; }
        public int IdCinema { get; set; }
        public int? Rating { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Genre { get; set; }

        public virtual Cinema IdCinemaNavigation { get; set; }
        public virtual ICollection<FilmCustom> FilmCustom { get; set; }
    }
}
