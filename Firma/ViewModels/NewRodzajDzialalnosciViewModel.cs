using Project.Models.Entities;
using Project.Models.Validators;
using Project.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class NewRodzajDzialalnosciViewModel : OneViewModel<RodzajDzialalnosci>, IDataErrorInfo
    {
        #region Konstruktor
        public NewRodzajDzialalnosciViewModel()
            : base("Rodzaj działalności")
        {
            Item = new RodzajDzialalnosci();
        }
        #endregion

        #region Properties
        public string NazwaRodzajuDzialalnosci
        {
            get
            {
                return Item.NazwaRodzajuDzialalnosci;
            }
            set
            {
                if (value != Item.NazwaRodzajuDzialalnosci)
                {
                    Item.NazwaRodzajuDzialalnosci = value;
                    base.OnPropertyChanged(() => NazwaRodzajuDzialalnosci);
                }
            }
        }
        public string Opis
        {
            get
            {
                return Item.Opis;
            }
            set
            {
                if (value != Item.Opis)
                {
                    Item.Opis = value;
                    base.OnPropertyChanged(() => Opis);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Database.RodzajDzialalnosci.AddObject(Item);
            Database.SaveChanges();
        }

        #endregion
        #region Validation       
        public string Error
        {
            get { return null; }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "NazwaRodzajuDzialalnosci")
                {
                    komunikat = StringValidator.IsUpper(NazwaRodzajuDzialalnosci);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaRodzajuDzialalnosci"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
