using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.EntitiesForView
{
    public class ZamowieniaForAllView
    {
        public int IdZamowienia { get; set; }
        public string NumerZamowienia { get; set; }
        public DateTime? DataZlozenia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string NazwaKontrahenta { get; set; }
        public string NazwaTowaru { get; set; }
        public string NazwaMagazynu {get; set;}
        public decimal? Wartosc { get; set; }
        public string CzyOplacone { get; set; }
        public string CzyPotwierdzone { get; set; }

    }
}
