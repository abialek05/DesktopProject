using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.BusinessLogic
{
    public class TowaryWystawione : DatabaseClass
    {
        #region Konstruktor
        public TowaryWystawione(InvoicesEntities invoicesEntities)
            : base(invoicesEntities)
        {
        }

        #endregion

        #region BusinessFunction

        public IEnumerable<object> WystawioneTowary(DateTime dataOd, DateTime dataDo)
        {
            return (
         from faktura in InvoicesEntities.Faktura
         join towar in InvoicesEntities.Towar on faktura.IdTowaru equals towar.IdTowaru
         where
             faktura.DataWystawienia >= dataOd &&
             faktura.DataSprzedazy <= dataDo &&
             faktura.CzyAktywna == true
         group faktura by towar.NazwaTowaru into temp
         select new
         {
             NazwaTowaru = temp.Key,
             IloscTowaru = temp.Sum(x => x.IloscTowaru)
         }         
     ).ToList();
        }

        #endregion
    }
}
