using Project.Models.Entities;
using Project.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.BusinessLogic
{
    public class KontrahentAktywne : DatabaseClass
    {
        #region Konstruktor
        public KontrahentAktywne(InvoicesEntities invoicesEntities)
            : base(invoicesEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetAktywniKontrahenci()
        {
            return
                (
                    from kontrahent in InvoicesEntities.Kontrahent
                    where kontrahent.CzyAktywny == true
                    select new KeyAndValue
                    {
                        Key = kontrahent.IdKontrahenta,
                        Value = kontrahent.NazwaKontrahenta
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
