using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.BusinessLogic
{
    public class UtargKontrahent : DatabaseClass
    {
        #region Konstruktor
        public UtargKontrahent(InvoicesEntities invoicesEntities)
            : base(invoicesEntities)
        {
        }

        #endregion

        #region BusinessFunction
        //to jest funkcja, która zwraca wielkość utargu dla wybranego towaru w wybranym okresie
        public decimal? KontrahentUtarg(int IdKontrahenta, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                from faktura in InvoicesEntities.Faktura
                where
                    faktura.IdKontrahenta == IdKontrahenta &&
                    faktura.DataWystawienia >= dataOd &&
                    faktura.TerminPlatnosci <= dataDo &&
                    faktura.CzyAktywna == true
                select
                    faktura.Kwota
                ).Sum();
        }
        #endregion
    }
}

