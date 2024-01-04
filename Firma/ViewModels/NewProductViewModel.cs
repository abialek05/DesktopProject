using GalaSoft.MvvmLight.Messaging;
using Project.Helpers;
using Project.Models;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using Project.Models.Validators;
using Project.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class NewProductViewModel : OneViewModel<Towar>, IDataErrorInfo
    {
        #region Konstruktor
        public NewProductViewModel()
            : base("Towar")
        {
            Item = new Towar();
            Messenger.Default.Register<GrupaTowaru>(this, getChosenGrupaTowaru);
            Messenger.Default.Register<TypTowaru>(this, getChosenTypTowaru);
            Messenger.Default.Register<JednostkaPodstawowa>(this, getChosenJednostkaPodstawowa);
        }
        #endregion
        #region Properties
        
        public string KodTowaru
        { get
            {
                return Item.KodTowaru;
            }
            set
            {
                if (value != Item.KodTowaru)
                {
                    Item.KodTowaru = value;
                    base.OnPropertyChanged(() => KodTowaru);
                }
            }
        }       

        public string NazwaTowaru
        {
            get { return Item.NazwaTowaru; }
            set
            {
                if (value != Item.NazwaTowaru)
                {
                    Item.NazwaTowaru = value;
                    base.OnPropertyChanged(() => NazwaTowaru);
                }
            }
        }

        public IQueryable<KeyAndValue> GrupyTowaruComboBoxItems
        {
            get
            {
                return
                    (
                        from grupaTowaru in Database.GrupaTowaru
                        select new KeyAndValue
                        {
                            Key = grupaTowaru.IdGrupyTowaru,
                            Value = grupaTowaru.NazwaGrupyTowaru
                        }
                    ).ToList().AsQueryable();
            }
        }

        public IQueryable<KeyAndValue> TypyTowaruComboBoxItems
        {
            get
            {
                return
                    (
                        from typTowaru in Database.TypTowaru
                        select new KeyAndValue
                        {
                            Key = typTowaru.IdTypuTowaru,
                            Value = typTowaru.NazwaTypu
                        }
                    ).ToList().AsQueryable();
            }
        }

        public string KodEAN
        {
            get { return Item.KodEAN; }
            set
            {
                if (value != Item.KodEAN)
                {
                    Item.KodEAN = value;
                    base.OnPropertyChanged(() => KodEAN);
                }
            }
        }

        public decimal? StawkaVatSprzedazy
        {
            get { return Item.StawkaVatSprzedazy; }
            set
            {
                if (value != Item.StawkaVatSprzedazy)
                {
                    Item.StawkaVatSprzedazy = value;
                    base.OnPropertyChanged(() => StawkaVatSprzedazy);
                }
            }
        }
        public decimal? StawkaVatZakupu
        {
            get { return Item.StawkaVatZakupu; }
            set
            {
                if (value != Item.StawkaVatZakupu)
                {
                    Item.StawkaVatZakupu = value;
                    base.OnPropertyChanged(() => StawkaVatZakupu);
                }
            }
        }
        public int? IdGrupyTowaru
        {
            get
            {
                return Item.IdGrupyTowaru;
            }
            set
            {
                if (value != Item.IdGrupyTowaru)
                {
                    Item.IdGrupyTowaru = value;
                    base.OnPropertyChanged(() => IdGrupyTowaru);
                }
            }
        }
        private string _GrupaTowaruNazwa;
        public string GrupaTowaruNazwa
        {
            get
            {
                return _GrupaTowaruNazwa;
            }
            set
            {
                if (value != _GrupaTowaruNazwa)
                {
                    _GrupaTowaruNazwa = value;
                    base.OnPropertyChanged(() => _GrupaTowaruNazwa);
                }
            }
        }
        public int? IdTypuTowaru
        {
            get
            {
                return Item.IdTypuTowaru;
            }
            set
            {
                if (value != Item.IdTypuTowaru)
                {
                    Item.IdTypuTowaru = value;
                    base.OnPropertyChanged(() => IdTypuTowaru);
                }
            }
        }
        private string _TypTowaruNazwa;
        public string TypTowaruNazwa
        {
            get
            {
                return _TypTowaruNazwa;
            }
            set
            {
                if (value != _TypTowaruNazwa)
                {
                    _TypTowaruNazwa = value;
                    base.OnPropertyChanged(() => _TypTowaruNazwa);
                }
            }
        }
        public int? IdJednostkiPodstawowej
        {
            get
            {
                return Item.IdJednostkiPodstawowej;
            }
            set
            {
                if (value != Item.IdJednostkiPodstawowej)
                {
                    Item.IdJednostkiPodstawowej = value;
                    base.OnPropertyChanged(() => IdJednostkiPodstawowej);
                }
            }
        }
        private string _JednostkaPodstawowaNazwa;
        public string JednostkaPodstawowaNazwa
        {
            get
            {
                return _JednostkaPodstawowaNazwa;
            }
            set
            {
                if (value != _JednostkaPodstawowaNazwa)
                {
                    _JednostkaPodstawowaNazwa = value;
                    base.OnPropertyChanged(() => _JednostkaPodstawowaNazwa);
                }
            }
        }
        #endregion
        #region Helpers

        private void getChosenGrupaTowaru(GrupaTowaru grupaTowaru)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdGrupyTowaru = grupaTowaru.IdGrupyTowaru;
            GrupaTowaruNazwa = grupaTowaru.NazwaGrupyTowaru;
        }

        private void getChosenTypTowaru(TypTowaru typTowaru)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdTypuTowaru = typTowaru.IdTypuTowaru;
            TypTowaruNazwa = typTowaru.NazwaTypu;
        }
        private void getChosenJednostkaPodstawowa(JednostkaPodstawowa jednostkaPodstawowa)
        {
            // to jest funkcja, która jest uruchamiana po przesłaniu z okna WszyscyKontrahenci wybranego kontrahenta
            IdJednostkiPodstawowej = jednostkaPodstawowa.IdJednostkiPodstawowej;
            JednostkaPodstawowaNazwa = jednostkaPodstawowa.NazwaJednostki;
        }

        #endregion
        #region Command
        private BaseCommand _ShowGrupyTowaruCommand;
        public ICommand ShowGrupyTowaruCommand
        {
            get
            {
                if (_ShowGrupyTowaruCommand == null)
                {
                    _ShowGrupyTowaruCommand = new BaseCommand(() => showGrupyTowaru());
                }
                return _ShowGrupyTowaruCommand;
            }
        }

        private BaseCommand _ShowTypyTowaruCommand;
        public ICommand ShowTypyTowaruCommand
        {
            get
            {
                if (_ShowTypyTowaruCommand == null)
                {
                    _ShowTypyTowaruCommand = new BaseCommand(() => showTypyTowaru());
                }
                return _ShowTypyTowaruCommand;
            }
        }
        private BaseCommand _ShowJednostkiPodstawoweCommand;
        public ICommand ShowJednostkiPodstawoweCommand
        {
            get
            {
                if (_ShowJednostkiPodstawoweCommand == null)
                {
                    _ShowJednostkiPodstawoweCommand = new BaseCommand(() => showJednostkiPodstawowe());
                }
                return _ShowJednostkiPodstawoweCommand;
            }
        }
        public void showGrupyTowaru()
        {
            Messenger.Default.Send("GrupyTowaruAll");
        }
        public void showTypyTowaru()
        {
            Messenger.Default.Send("TypyTowaruAll");
        }
        public void showJednostkiPodstawowe()
        {
            Messenger.Default.Send("JednostkiAll");
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Database.Towar.AddObject(Item);
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
                if (name == "StawkaVatSprzedazy")
                {
                    komunikat = BusinessValidator.CheckVat(StawkaVatSprzedazy);
                } 
                if (name == "StawkaVatZakupu")
                {
                    komunikat = BusinessValidator.CheckVat(StawkaVatZakupu);
                }
                if (name == "KodEAN")
                {
                    komunikat = StringValidator.CheckEan(KodEAN);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["KodEAN"] == null && this["StawkaVatSprzedazy"] == null && this["StawkaVatZakupu"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}

