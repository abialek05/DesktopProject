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
    public class NewSposobPlatnosciViewModel : OneViewModel<SposobPlatnosci>, IDataErrorInfo
    {
        #region Konstruktor
        public NewSposobPlatnosciViewModel()
            : base("Sposób płatności")
        {
            Item = new SposobPlatnosci();
        }
        #endregion
        #region Properties
        public string NazwaSposobuPlatnosci
        {
            get
            {
                return Item.NazwaSposobuPlatnosci;
            }
            set
            {
                if (value != Item.NazwaSposobuPlatnosci)
                {
                    Item.NazwaSposobuPlatnosci = value;
                    base.OnPropertyChanged(() => NazwaSposobuPlatnosci);
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
        public string Uwagi
        {
            get
            {
                return Item.Uwagi;
            }
            set
            {
                if (value != Item.Uwagi)
                {
                    Item.Uwagi = value;
                    base.OnPropertyChanged(() => Uwagi);
                }
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Database.SposobPlatnosci.AddObject(Item);
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
                if (name == "NazwaSposobuPlatnosci")
                {
                    komunikat = StringValidator.IsUpper(NazwaSposobuPlatnosci);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaSposobuPlatnosci"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
