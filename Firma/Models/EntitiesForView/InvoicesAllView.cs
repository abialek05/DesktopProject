using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.EntitiesForView
{
    public class InvoicesAllView
    {
        #region Properties
        public int IdFaktury { get; set; }
        public string NumerFaktury { get; set; }

        // --Wyswietlanie kontrahenta--
        public string KontrahentNazwa { get; set; }
        public string KontrahentNIP { get; set; }

        // --Wyswietlanie kategorii faktury--

        public string KategoriaFakturyNazwa { get; set; }

        public DateTime? DataWystawienia { get; set; }
        public DateTime? DataSprzedazy { get; set; }

        // --Wyswietlanie pozycji faktury --

        public string TowarNazwaTowaru { get; set; }
        public decimal? Kwota { get; set; }
        public decimal? IloscTowaru { get; set; }

        // --Wyswietlanie sposobu platnosci

        public string SposobPlatnosciNazwa { get; set; }

        public DateTime? TerminPlatnosci { get; set; }
        #endregion


    }
}
