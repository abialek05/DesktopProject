using Project.Models.Entities;
using Project.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.BusinessLogic
{
    public class CennikAktywne : DatabaseClass
    {
        #region Konstruktor
        public CennikAktywne(InvoicesEntities invoicesEntities)
            : base(invoicesEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetAktywneCenniki()
        {
            return
                (
                    from cennik in InvoicesEntities.Cennik 
                    where cennik.CzyAktywny == true 
                    select new KeyAndValue 
                    {
                        Key = cennik.IdCennika,
                        Value = cennik.NazwaCennika
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
