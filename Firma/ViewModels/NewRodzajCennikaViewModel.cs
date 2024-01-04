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
    public class NewRodzajCennikaViewModel : OneViewModel<RodzajCennika>, IDataErrorInfo
    {
        #region Konstruktor
        public NewRodzajCennikaViewModel()
            : base("Rodzaj cennika")
        {
            Item = new RodzajCennika();
        }
        #endregion

        #region Properties        
        public string NazwaRodzajuCennika
        {
            get
            {
                return Item.NazwaRodzajuCennika;
            }
            set
            {
                if (value != Item.NazwaRodzajuCennika)
                {
                    Item.NazwaRodzajuCennika = value;
                    base.OnPropertyChanged(() => NazwaRodzajuCennika);
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
            Database.RodzajCennika.AddObject(Item);
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
                if (name == "NazwaRodzajuCennika")
                {
                    komunikat = StringValidator.IsUpper(NazwaRodzajuCennika);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaRodzajuCennika"] == null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
