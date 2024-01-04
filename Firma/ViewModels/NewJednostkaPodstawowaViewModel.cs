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
    public class NewJednostkaPodstawowaViewModel : OneViewModel<JednostkaPodstawowa>, IDataErrorInfo
    {
        #region Konstruktor
        public NewJednostkaPodstawowaViewModel()
            : base("Jednostka podstawowa")
        {
            Item = new JednostkaPodstawowa();
        }
        #endregion

        #region Properties
        public string NazwaJednostki
        {
            get
            {
                return Item.NazwaJednostki;
            }
            set
            {
                if (value != Item.NazwaJednostki)
                {
                    Item.NazwaJednostki = value;
                    base.OnPropertyChanged(() => NazwaJednostki);
                }
            }
        }        
        public string KodJednostki
        {
            get
            {
                return Item.KodJednostki;
            }
            set
            {
                if (value != Item.KodJednostki)
                {
                    Item.KodJednostki = value;
                    base.OnPropertyChanged(() => KodJednostki);
                }
            }
        }        

        #endregion

       #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Database.JednostkaPodstawowa.AddObject(Item);
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
                if (name == "NazwaJednostki")
                {
                    komunikat = StringValidator.IsUpper(NazwaJednostki);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaJednostki"] == null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
