using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.EntitiesForView
{
    public class CennikForAllView
    {
        public int IdCennika { get; set; }
        public string NazwaCennika { get; set; }
        public decimal? Cena { get; set; }
        public DateTime? DataDataObowiazywaniaOd { get; set; }
        public DateTime? DataDataObowiazywaniaDo { get; set; }
        public string NazwaTowaru { get; set; }

    }
}
