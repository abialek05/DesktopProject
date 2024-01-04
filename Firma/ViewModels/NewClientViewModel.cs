using GalaSoft.MvvmLight.Messaging;
using Project.Helpers;
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
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class NewClientViewModel : OneViewModel<Kontrahent>, IDataErrorInfo
    {
        #region Command
        private BaseCommand _ShowRodzajeDzialalnosciCommand;
        public ICommand ShowRodzajeDzialalnosciCommand
        {
            get
            {
                if (_ShowRodzajeDzialalnosciCommand == null)
                {
                    _ShowRodzajeDzialalnosciCommand = new BaseCommand(() => showRodzajeDzialalnosci());
                }
                return _ShowRodzajeDzialalnosciCommand;
            }
        }
        private BaseCommand _ShowBranzeCommand;
        public ICommand ShowBranzeCommand
        {
            get
            {
                if (_ShowBranzeCommand == null)
                {
                    _ShowBranzeCommand = new BaseCommand(() => showBranze());
                }
                return _ShowBranzeCommand;
            }
        }       

        public void showRodzajeDzialalnosci()
        {
            Messenger.Default.Send("RodzajeDzialalnosciAll");
        }

        public void showBranze()
        {
            Messenger.Default.Send("BranzeAll");
        }
       
        #endregion
        #region Konstruktory
        public NewClientViewModel()
            : base("Kontrahent")
        {
            Item = new Kontrahent();
            Messenger.Default.Register<RodzajDzialalnosci>(this, getChosenRodzajDzialalnosci);
            Messenger.Default.Register<Branza>(this, getChosenBranza);
        }
        #endregion
        #region Helpers

        private void getChosenRodzajDzialalnosci(RodzajDzialalnosci rodzajDzialalnosci)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdRodzajuDzialalnosci = rodzajDzialalnosci.IdRodzajuDzialalnosci;
        }

        private void getChosenBranza(Branza branza)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdBranzy = branza.IdBranzy;                
        }
       

        #endregion
        #region Properties
        public string NazwaKontrahenta
        {
            get
            {
                return Item.NazwaKontrahenta;
            }
            set
            {
                if (value != Item.NazwaKontrahenta)
                {
                    Item.NazwaKontrahenta = value;
                    base.OnPropertyChanged(() => NazwaKontrahenta);
                }
            }
        }

        public string KodKontrahenta
        {
            get
            {
                return Item.KodKontrahenta;
            }
            set
            {
                if (value != Item.KodKontrahenta)
                {
                    Item.KodKontrahenta = value;
                    base.OnPropertyChanged(() => KodKontrahenta);
                }
            }
        }
        public string Email
        {
            get
            {
                return Item.Email;
            }
            set
            {
                if (value != Item.Email)
                {
                    Item.Email = value;
                    base.OnPropertyChanged(() => Email);
                }
            }
        }

        public string NIP
        {
            get
            {
                return Item.NIP;
            }
            set
            {
                if (value != Item.NIP)
                {
                    Item.NIP = value;
                    base.OnPropertyChanged(() => NIP);
                }
            }
        }

        public string REGON
        {
            get
            {
                return Item.REGON;
            }
            set
            {
                if (value != Item.REGON)
                {
                    Item.REGON = value;
                    base.OnPropertyChanged(() => REGON);
                }
            }
        }

        public string PESEL
        {
            get
            {
                return Item.PESEL;
            }
            set
            {
                if (value != Item.PESEL)
                {
                    Item.PESEL = value;
                    base.OnPropertyChanged(() => PESEL);
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
        public string Wojewodztwo
        {
            get
            {
                return Item.Wojewodztwo;
            }
            set
            {
                if (value != Item.Wojewodztwo)
                {
                    Item.Wojewodztwo = value;
                    base.OnPropertyChanged(() => Wojewodztwo);
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

        public string Telefon
        {
            get
            {
                return Item.Telefon;
            }
            set
            {
                if (value != Item.Telefon)
                {
                    Item.Telefon = value;
                    base.OnPropertyChanged(() => Telefon);
                }
            }
        }

        public string Fax
        {
            get
            {
                return Item.Fax;
            }
            set
            {
                if (value != Item.Fax)
                {
                    Item.Fax = value;
                    base.OnPropertyChanged(() => Fax);
                }
            }
        }

        public string AdresWWW
        {
            get
            {
                return Item.AdresWWW;
            }
            set
            {
                if (value != Item.AdresWWW)
                {
                    Item.AdresWWW = value;
                    base.OnPropertyChanged(() => AdresWWW);
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

        public int? IdRodzajuDzialalnosci
        {
            get
            {
                return Item.IdRodzajuDzialalnosci;
            }
            set
            {
                if (value != Item.IdRodzajuDzialalnosci)
                {
                    Item.IdRodzajuDzialalnosci = value;
                    base.OnPropertyChanged(() => IdRodzajuDzialalnosci);
                }
            }
        }
        public int? IdBranzy
        {
            get
            {
                return Item.IdBranzy;
            }
            set
            {
                if (value != Item.IdBranzy)
                {
                    Item.IdBranzy = value;
                    base.OnPropertyChanged(() => IdBranzy);
                }
            }
        }

        public IQueryable<KeyAndValue> RodzajDzialalnosciComboBoxItems
        {
            get
            {
                return
                    (
                        from rodzajDzialalnosci in Database.RodzajDzialalnosci
                        select new KeyAndValue
                        {
                            Key = rodzajDzialalnosci.IdRodzajuDzialalnosci,
                            Value = rodzajDzialalnosci.NazwaRodzajuDzialalnosci
                        }
                    ).ToList().AsQueryable();
            }
        }

        public IQueryable<KeyAndValue> BranzaComboBoxItems
        {
            get
            {
                return
                    (
                        from branza in Database.Branza
                        select new KeyAndValue
                        {
                            Key = branza.IdBranzy,
                            Value = branza.NazwaBranzy
                        }
                    ).ToList().AsQueryable();
            }
        }       

        public override void Save()
        {
            Item.CzyAktywny = true;
            Database.Kontrahent.AddObject(Item);
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
                if (name == "NazwaKontrahenta")
                {
                    komunikat = StringValidator.IsUpper(NazwaKontrahenta);
                }
                if (name == "KodKontrahenta")
                {
                    komunikat = StringValidator.IsUpper(KodKontrahenta);
                }
                if (name == "Ulica")
                {
                    komunikat = StringValidator.IsUpper(Ulica);
                }
                if (name == "Miasto")
                {
                    komunikat = StringValidator.IsUpper(Miasto);
                }
                if (name == "KodPocztowy")
                {
                    komunikat = StringValidator.IsKodPocztowy(KodPocztowy);
                }
                if (name == "Email")
                {
                    komunikat = StringValidator.IsEmail(Email);
                }
                if (name == "NIP")
                {
                    komunikat = StringValidator.IsNIP(NIP);
                }
                if (name == "REGON")
                {
                    komunikat = StringValidator.IsREGON(REGON);
                }
                if (name == "PESEL")
                {
                    komunikat = StringValidator.IsPESEL(PESEL);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Miasto"] == null && this["Email"] == null && this["KodPocztowy"] == null && this["NIP"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
