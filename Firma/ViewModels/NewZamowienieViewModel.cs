using GalaSoft.MvvmLight.Messaging;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using Project.Models.Validators;
using Project.ViewModels.Abstract;
using Project.ViewResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal class NewZamowienieViewModel : OneViewModel<Zamowienie>, IDataErrorInfo
    {
        #region Konstruktor
        public NewZamowienieViewModel()
        : base("Zamówienie")
        {
            Item = new Zamowienie();
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywne = true;
            Database.Zamowienie.AddObject(Item);
            Database.SaveChanges();
        }

        #endregion
        #region Properties

        public string NumerZamowienia
        {
            get
            {
                return Item.NumerZamowienia;
            }
            set
            {
                if (value != Item.NumerZamowienia)
                {
                    Item.NumerZamowienia = value;
                    base.OnPropertyChanged(() => NumerZamowienia);
                }
            }
        }

        public DateTime? DataZlozenia
        {
            get
            {
                return Item.DataZlozenia;
            }
            set
            {
                if (value != Item.DataZlozenia)
                {
                    Item.DataZlozenia = value;
                    base.OnPropertyChanged(() => DataZlozenia);
                }
            }
        }
        public DateTime? DataRealizacji
        {
            get
            {
                return Item.DataRealizacji;
            }
            set
            {
                if (value != Item.DataRealizacji)
                {
                    Item.DataRealizacji = value;
                    base.OnPropertyChanged(() => DataRealizacji);
                }
            }
        }
        public string CzyOplacone
        {
            get
            {
                return Item.CzyOplacone;
            }
            set
            {

                if (value != Item.CzyOplacone)
                {
                    Item.CzyOplacone = value;
                    base.OnPropertyChanged(() => CzyOplacone);
                }

            }
        }

        public string CzyPotwierdzone
        {
            get
            {
                return Item.CzyPotwierdzone;
            }
            set
            {

                if (value != Item.CzyPotwierdzone)
                {
                    Item.CzyPotwierdzone = value;
                    base.OnPropertyChanged(() => CzyPotwierdzone);
                }

            }
        }



        public decimal? Wartosc
        {
            get
            {
                return Item.Wartosc;
            }
            set
            {
                if (value != Item.Wartosc)
                {
                    Item.Wartosc = value;
                    base.OnPropertyChanged(() => Wartosc);
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

        public int? IdKontrahenta
        {
            get
            {
                return Item.IdKontrahenta;
            }
            set
            {
                if (value != Item.IdKontrahenta)
                {
                    Item.IdKontrahenta = value;
                    base.OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }
        public int? IdMagazynu
        {
            get
            {
                return Item.IdMagazynu;
            }
            set
            {
                if (value != Item.IdMagazynu)
                {
                    Item.IdMagazynu = value;
                    base.OnPropertyChanged(() => IdMagazynu);
                }
            }
        }
        public int? IdTowaru
        {
            get
            {
                return Item.IdTowaru;
            }
            set
            {
                if (value != Item.IdTowaru)
                {
                    Item.IdTowaru = value;
                    base.OnPropertyChanged(() => IdTowaru);
                }
            }
        }


        public IQueryable<KeyAndValue> KontrahentComboBoxItems
        {
            get
            {
                return
                    (
                        from kontrahent in Database.Kontrahent
                        select new KeyAndValue
                        {
                            Key = kontrahent.IdKontrahenta,
                            Value = kontrahent.NazwaKontrahenta
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> TowarComboBoxItems
        {
            get
            {
                return
                    (
                        from towar in Database.Towar
                        select new KeyAndValue
                        {
                            Key = towar.IdTowaru,
                            Value = towar.NazwaTowaru
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> MagazynComboBoxItems
        {
            get
            {
                return
                    (
                        from magazyn in Database.Magazyn
                        select new KeyAndValue
                        {
                            Key = magazyn.IdMagazynu,
                            Value = magazyn.NazwaMagazynu + " | " + magazyn.KodPocztowy + ", " + magazyn.Miasto
                        }
                    ).ToList().AsQueryable();
            }
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
                if (name == "Wartosc")
                {
                    komunikat = BusinessValidator.CheckPrice(Wartosc);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Wartosc"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }

}
