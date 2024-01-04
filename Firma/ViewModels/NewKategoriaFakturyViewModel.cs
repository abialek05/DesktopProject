using Project.Models.Entities;
using Project.Models.Validators;
using Project.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class NewKategoriaFakturyViewModel : OneViewModel<KategoriaFaktury>, IDataErrorInfo
    {
        #region Konstruktor
        public NewKategoriaFakturyViewModel()
            : base("Kategoria faktury")
        {
            Item = new KategoriaFaktury();
        }

        public string NazwaKategorii
        {
            get
            {
                return Item.NazwaKategorii;
            }
            set
            {
                if (value != Item.NazwaKategorii)
                {
                    Item.NazwaKategorii = value;
                    base.OnPropertyChanged(() => NazwaKategorii);
                }
            }
        }
        public string KodKategorii
        {
            get
            {
                return Item.KodKategorii;
            }
            set
            {
                if (value != Item.KodKategorii)
                {
                    Item.KodKategorii = value;
                    base.OnPropertyChanged(() => KodKategorii);
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
        public DateTime? KiedyDodano
        {
            get 
            {
                return Item.KiedyDodano;
            }
            set 
            {
                value = DateTime.Now;
                Item.KiedyDodano = value;
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywna = true;
            Database.KategoriaFaktury.AddObject(Item);
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
                if (name == "NazwaKategorii")
                {
                    komunikat = StringValidator.IsUpper(NazwaKategorii);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaKategorii"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
