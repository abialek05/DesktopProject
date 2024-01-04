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
    public class NewTypTowaruViewModel : OneViewModel<TypTowaru>, IDataErrorInfo
    {
        #region Konstruktor
        public NewTypTowaruViewModel()
            : base("Typ towaru")
        {
            Item = new TypTowaru();
        }
        #endregion

        #region Properties        
        public string NazwaTypu
        {
            get
            {
                return Item.NazwaTypu;
            }
            set
            {
                if (value != Item.NazwaTypu)
                {
                    Item.NazwaTypu = value;
                    base.OnPropertyChanged(() => NazwaTypu);
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
        public string KodTypu
        {
            get
            {
                return Item.KodTypu;
            }
            set
            {
                if (value != Item.KodTypu)
                {
                    Item.KodTypu = value;
                    base.OnPropertyChanged(() => KodTypu);
                }
            }
        }
        #endregion


        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Database.TypTowaru.AddObject(Item);
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
                if (name == "NazwaTypu")
                {
                    komunikat = StringValidator.IsUpper(NazwaTypu);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaTypu"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
