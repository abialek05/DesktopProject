using Project.Models.Entities;
using Project.Models.EntitiesForView;
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
    public class NewMagazynViewModel : OneViewModel<Magazyn>, IDataErrorInfo
    {

        #region Konstruktor
        public NewMagazynViewModel()
        : base("Magazyn")
        {


            Item = new Magazyn();
        }

        #endregion
        #region Properties
        public string NazwaMagazynu
        {
            get
            {
                return Item.NazwaMagazynu;
            }
            set
            {
                if (value != Item.NazwaMagazynu)
                {
                    Item.NazwaMagazynu = value;
                    base.OnPropertyChanged(() => NazwaMagazynu);
                }
            }
        }

        public string RodzajMagazynu
        {
            get
            {
                return Item.RodzajMagazynu;
            }
            set
            {
                if (value != Item.RodzajMagazynu)
                {
                    Item.RodzajMagazynu = value;
                    base.OnPropertyChanged(() => RodzajMagazynu);
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

        public string Kraj
        {
            get
            {
                return Item.Kraj;
            }
            set
            {
                if (value != Item.Kraj)
                {
                    Item.Kraj = value;
                    base.OnPropertyChanged(() => Kraj);
                }
            }
        }

        public string Miasto
        {
            get
            {
                return Item.Miasto;
            }
            set
            {
                if (value != Item.Miasto)
                {
                    Item.Miasto = value;
                    base.OnPropertyChanged(() => Miasto);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return Item.KodPocztowy;
            }
            set
            {
                if (value != Item.KodPocztowy)
                {
                    Item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }

        public string Ulica
        {
            get
            {
                return Item.Ulica;
            }
            set
            {
                if (value != Item.Ulica)
                {
                    Item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }

        public string NumerUlicy
        {
            get
            {
                return Item.NumerUlicy;
            }
            set
            {
                if (value != Item.NumerUlicy)
                {
                    Item.NumerUlicy = value;
                    base.OnPropertyChanged(() => NumerUlicy);
                }
            }
        }

        public string NumerBudynku
        {
            get
            {
                return Item.NumerBudynku;
            }
            set
            {
                if (value != Item.NumerBudynku)
                {
                    Item.NumerBudynku = value;
                    base.OnPropertyChanged(() => NumerBudynku);
                }
            }
        }

        public string Poczta
        {
            get
            {
                return Item.Poczta;
            }
            set
            {
                if (value != Item.Poczta)
                {
                    Item.Poczta = value;
                    base.OnPropertyChanged(() => Poczta);
                }
            }
        }

        public IQueryable<KeyAndValue> WojewodztwoComboBoxItems
        {
            get
            {
                return
                    (
                        from wojewodztwo in Database.Wojewodztwa
                        select new KeyAndValue
                        {
                            Key = wojewodztwo.Id,
                            Value = wojewodztwo.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }

        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Database.Magazyn.AddObject(Item);
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
                if (name == "NazwaMagazynu")
                {
                    komunikat = StringValidator.IsUpper(NazwaMagazynu);
                }
                if (name == "Kraj")
                {
                    komunikat = StringValidator.IsUpper(Kraj);
                }
                if (name == "Miasto")
                {
                    komunikat = StringValidator.IsUpper(Miasto);
                } 
                if (name == "KodPocztowy")
                {
                    komunikat = StringValidator.IsKodPocztowy(KodPocztowy);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaMagazynu"] == null && this["Kraj"] == null && this["Miasto"] == null && this["KodPocztowy"] == null)
            {
                return true;
            }
            return false;
        }
        #endregion
    
}
}