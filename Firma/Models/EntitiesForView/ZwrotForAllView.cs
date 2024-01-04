using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.EntitiesForView
{
    public class ZwrotForAllView
    {
        #region Properties
        public int IdZwrotu { get; set; }
        public string KodZwrotu { get; set; }
        public string NumerFaktury { get; set; }
        public string NazwaKontrahenta { get; set; }
        public string AdresKontrahenta { get; set; }
        public string NazwaTowaru { get; set; }
        public string NazwaMagazynu { get; set; }
        public string AdresMagazynu { get; set; }
        #endregion
    }
}
