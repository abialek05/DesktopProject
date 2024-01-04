using GalaSoft.MvvmLight.Messaging;
using Project.Helpers;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using Project.Models.Validators;
using Project.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class NewZwrotViewModel : OneViewModel<Zwrot>, IDataErrorInfo
    {
        #region Konstruktor
        public NewZwrotViewModel()
        : base("Zwrot")
        {
            Item = new Zwrot();
            Messenger.Default.Register<KontrahentAllView>(this, getChosenClient);
            Messenger.Default.Register<InvoicesAllView>(this, getChosenInvoice);
            Messenger.Default.Register<TowarAllView>(this, getChosenProduct);
            Messenger.Default.Register<MagazynAllView>(this, getChosenMagazyn);
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
        private BaseCommand _ShowInvoicesCommand;
        public ICommand ShowInvoicesCommand
        {
            get
            {
                if (_ShowInvoicesCommand == null)
                {
                    _ShowInvoicesCommand = new BaseCommand(() => showInvoices());
                }
                return _ShowInvoicesCommand;
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
        private BaseCommand _ShowMagazynCommand;
        public ICommand ShowMagazynCommand
        {
            get
            {
                if (_ShowMagazynCommand == null)
                {
                    _ShowMagazynCommand = new BaseCommand(() => showMagazyn());
                }
                return _ShowMagazynCommand;
            }
        }

        public void showClients()
        {
            Messenger.Default.Send("ClientsAll");
        }

        public void showInvoices()
        {
            Messenger.Default.Send("InvoicesAll");
        }
        public void showProducts()
        {
            Messenger.Default.Send("ProductsAll");
        }
        public void showMagazyn()
        {
            Messenger.Default.Send("MagazynAll");
        }


        #endregion

        #region Properties

        public string KodZwrotu
        {
            get
            {
                return Item.KodZwrotu;
            }
            set
            {
                if (value != Item.KodZwrotu)
                {
                    Item.KodZwrotu = value;
                    base.OnPropertyChanged(() => KodZwrotu);
                }
            }
        }

        public decimal KwotaZwrotu
        {
            get
            {
                return Item.KwotaZwrotu;
            }
            set
            {
                if (value != Item.KwotaZwrotu)
                {
                    Item.KwotaZwrotu = value;
                    base.OnPropertyChanged(() => KwotaZwrotu);
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

        public IQueryable<KeyAndValue> FakturaComboBoxItems
        {
            get
            {
                return
                    (
                        from faktura in Database.Faktura
                        select new KeyAndValue
                        {
                            Key = faktura.IdFaktury,
                            Value = faktura.NumerFaktury
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
        public int IdKontrahenta
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

        public int IdFaktury
        {
            get
            {
                return Item.IdFaktury;
            }
            set
            {
                if (value != Item.IdFaktury)
                {
                    Item.IdFaktury = value;
                    base.OnPropertyChanged(() => IdFaktury);
                }
            }
        }

        public int IdTowaru
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
        public int IdMagazynu
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


        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Database.Zwrot.AddObject(Item);
            Database.SaveChanges();
        }

        #endregion

        #region Helpers

        private void getChosenClient(KontrahentAllView kontrahentAllView)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdKontrahenta = kontrahentAllView.IdKontrahenta;
        }

        private void getChosenInvoice(InvoicesAllView invoicesAllView)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdFaktury = invoicesAllView.IdFaktury;
        }

        private void getChosenProduct(TowarAllView productAllView)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdTowaru = productAllView.IdTowaru;
        }
        private void getChosenMagazyn(MagazynAllView magazynAllView)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdMagazynu = magazynAllView.IdMagazynu;
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
                if (name == "KwotaZwrotu")
                {
                    komunikat = BusinessValidator.CheckPrice(KwotaZwrotu);
                }                

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["KwotaZwrotu"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}

