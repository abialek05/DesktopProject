using Project.Models.Entities;
using Project.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.BusinessLogic
{
    public class TowarAktywne : DatabaseClass
    {
        #region Konstruktor
        public TowarAktywne(InvoicesEntities invoicesEntities)
            : base(invoicesEntities)
        { 
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetAktywneTowary()
        {
            return
                (
                    from towar in InvoicesEntities.Towar //dla każdego towaru z bazy danych towarów
                    where towar.CzyAktywny == true //który jest aktywny
                    select new KeyAndValue //tworzymy KeyAndValue
                    {
                        Key = towar.IdTowaru,
                        Value = towar.NazwaTowaru
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
