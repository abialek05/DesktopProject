using Project.Models.Entities;
using Project.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.BusinessLogic
{
    public class FakturyAktywne : DatabaseClass    
    {
        #region Konstruktor
        public FakturyAktywne(InvoicesEntities invoicesEntities)
            : base(invoicesEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetAktywneFaktury()
        {
            return
                (
                    from faktura in InvoicesEntities.Faktura 
                    where faktura.CzyAktywna == true 
                    select new KeyAndValue 
                    {
                        Key = faktura.IdFaktury,
                        Value = faktura.NumerFaktury
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}

