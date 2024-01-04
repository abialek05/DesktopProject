using GalaSoft.MvvmLight.Messaging;
using Project.Helpers;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using Project.Models.Validators;
using Project.ViewModels.Abstract;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class NewInvoiceViewModel : OneViewModel<Faktura>, IDataErrorInfo
    {
        #region Konstruktor
        public NewInvoiceViewModel()
            : base("Faktura")
        {
            Item = new Faktura();
            Messenger.Default.Register<KontrahentAllView>(this, getChosenClient);
            Messenger.Default.Register<TowarAllView>(this, getChosenProduct);
            Messenger.Default.Register<CennikForAllView>(this, getChosenCennik);
        }
        #endregion
        #region Properties

        public string NumerFaktury
        {
            get
            {
                return Item.NumerFaktury;
            }
            set
            {
                if (value != Item.NumerFaktury)
                {
                    Item.NumerFaktury = value;
                    base.OnPropertyChanged(() => NumerFaktury);
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
        public IQueryable<KeyAndValue> KategoriaFakturyComboBoxItems
        {
            get
            {
                return
                    (
                        from kategoriaFaktury in Database.KategoriaFaktury
                        select new KeyAndValue
                        {
                            Key = kategoriaFaktury.IdKategoriiFaktury,
                            Value = kategoriaFaktury.NazwaKategorii
                        }
                    ).ToList().AsQueryable();
            }
        }

        public IQueryable<KeyAndValue> PozycjaFakturyComboBoxItems
        {
            get
            {
                return
                    (
                        from pozycjaFaktury in Database.PozycjaFaktury
                        select new KeyAndValue
                        {
                            Key = pozycjaFaktury.IdPozycjiFaktury,
                            Value = pozycjaFaktury.Rabat.ToString()
                        }
                    ).ToList().AsQueryable();
            }
        }

        public IQueryable<KeyAndValue> SposobPlatnosciComboBoxItems
        {
            get
            {
                return
                    (
                        from sposobPlatnosci in Database.SposobPlatnosci
                        select new KeyAndValue
                        {
                            Key = sposobPlatnosci.IdSposobuPlatnosci,
                            Value = sposobPlatnosci.NazwaSposobuPlatnosci
                        }
                    ).ToList().AsQueryable();
            }
        }

        public DateTime? DataWystawienia
        {
            get
            {
                return Item.DataWystawienia;
            }
            set
            {
                if (value != Item.DataWystawienia)
                {
                    Item.DataWystawienia = value;
                    base.OnPropertyChanged(() => DataWystawienia);
                }
            }
        }

        public DateTime? DataSprzedazy
        {
            get
            {
                return Item.DataSprzedazy;
            }
            set
            {
                if (value != Item.DataSprzedazy)
                {
                    Item.DataSprzedazy = value;
                    base.OnPropertyChanged(() => DataSprzedazy);
                }
            }
        }
        public DateTime? TerminPlatnosci
        {
            get
            {
                return Item.TerminPlatnosci;
            }
            set
            {
                if (value != Item.TerminPlatnosci)
                {
                    Item.TerminPlatnosci = value;
                    base.OnPropertyChanged(() => TerminPlatnosci);
                }
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

        public int? IdCennika
        {
            get
            {
                return Item.IdCennika;
            }
            set
            {
                if (value != Item.IdCennika)
                {
                    Item.IdCennika = value;
                    base.OnPropertyChanged(() => IdCennika);
                }
            }
        }
        public IQueryable<KeyAndValue> CennikComboBoxItems
        {
            get
            {
                return
                    (
                        from cennik in Database.Cennik
                        select new KeyAndValue
                        {
                            Key = cennik.IdCennika,
                            Value = cennik.NazwaCennika
                        }
                    ).ToList().AsQueryable();
            }
        }
        public decimal? IloscTowaru
        {
            get
            {
                return Item.IloscTowaru;
            }
            set
            {
                if (value != Item.IloscTowaru)
                {
                    Item.IloscTowaru = value;
                    base.OnPropertyChanged(() => IloscTowaru);
                }
            }
        }
        public decimal? Kwota
        {
            get
            {
                return Item.Kwota;
            }
            set
            {
                if (value != Item.Kwota)
                {
                    Item.Kwota = value;
                    base.OnPropertyChanged(() => Kwota);
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
        public int? IdSposobuPlatnosci
        {
            get
            {
                return Item.IdSposobuPlatnosci;
            }
            set
            {
                if (value != Item.IdSposobuPlatnosci)
                {
                    Item.IdSposobuPlatnosci = value;
                    base.OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }
        public int? IdKategoriiFaktury
        {
            get
            {
                return Item.IdKategoriiFaktury;
            }
            set
            {
                if (value != Item.IdKategoriiFaktury)
                {
                    Item.IdKategoriiFaktury = value;
                    base.OnPropertyChanged(() => IdKategoriiFaktury);
                }
            }
        }
        private decimal? _Cena;
        public decimal? Cena
        {
            get
            {
                return _Cena;
            }
            set
            {
                if (value != _Cena)
                {
                    _Cena = value;
                    base.OnPropertyChanged(() => _Cena);
                }
            }
        }

        #endregion
        #region Helpers

        private void getChosenClient(KontrahentAllView kontrahentAllView)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdKontrahenta = kontrahentAllView.IdKontrahenta;
        }

        private void getChosenProduct(TowarAllView productAllView)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdTowaru = productAllView.IdTowaru;
        }
        private void getChosenCennik(CennikForAllView cennikForAllView)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdCennika = cennikForAllView.IdCennika;
            Cena = cennikForAllView.Cena;
        }

        #endregion
        #region Command
        private BaseCommand _ShowClientsCommand;
        public ICommand ShowClientsCommand
        {
            get
            {
                if (_ShowClientsCommand == null)
                {
                    _ShowClientsCommand = new BaseCommand(() => showClients());
                }
                return _ShowClientsCommand;
            }
        }

        private BaseCommand _ShowProductsCommand;
        public ICommand ShowProductsCommand
        {
            get
            {
                if (_ShowProductsCommand == null)
                {
                    _ShowProductsCommand = new BaseCommand(() => showProducts());
                }
                return _ShowProductsCommand;
            }
        }
        private BaseCommand _ShowCennikCommand;
        public ICommand ShowCennikCommand
        {
            get
            {
                if (_ShowCennikCommand == null)
                {
                    _ShowCennikCommand = new BaseCommand(() => showCennik());
                }
                return _ShowCennikCommand;
            }
        }
        public void showClients()
        {
            Messenger.Default.Send("ClientsAll");
        }
        public void showProducts()
        {
            Messenger.Default.Send("ProductsAll");
        }
        public void showCennik()
        {
            Messenger.Default.Send("CennikAll");
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywna = true;
            Database.Faktura.AddObject(Item);
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
                if (name == "NumerFaktury")
                {
                    komunikat = StringValidator.IsUpper(NumerFaktury);
                } 
                if (name == "Kwota")
                {
                    komunikat = BusinessValidator.CheckPrice(Kwota);
                }                 
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NumerFaktury"] == null || this["Kwota"] == null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
