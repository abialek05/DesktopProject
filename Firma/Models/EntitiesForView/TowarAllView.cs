using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.EntitiesForView
{
    public class TowarAllView
    {
        #region Properties
        public int IdTowaru { get; set; }
        public string KodTowaru { get; set; }
        public string NazwaTowaru { get; set; }
        public string TypTowaruNazwa { get; set; }
        public string KodEAN { get; set; }
        public string GrupaTowaruNazwa { get; set; }
        public decimal? StawkaVatSprzedazy { get; set; }
        public decimal? StawkaVatZakupu { get; set; }

        #endregion
    }
}
