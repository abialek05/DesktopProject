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
    public class NewCennikViewModel : OneViewModel<Cennik>, IDataErrorInfo
    {
        #region Konstruktor
        public NewCennikViewModel()
            : base("Cennik")
        {
            Item = new Cennik();
        }
        #endregion
        #region Command
        private BaseCommand _ShowTowarCommand;
        public ICommand ShowTowarCommand
        {
            get
            {
                if (_ShowTowarCommand == null)
                {
                    _ShowTowarCommand = new BaseCommand(() => showTowar());
                }
                return _ShowTowarCommand;
            }
        }
        private BaseCommand _ShowRodzajCennikaCommand;
        public ICommand ShowRodzajCennikaCommand
        {
            get
            {
                if (_ShowRodzajCennikaCommand == null)
                {
                    _ShowRodzajCennikaCommand = new BaseCommand(() => showRodzajCennika());
                }
                return _ShowRodzajCennikaCommand;
            }
        }
        public void showTowar()
        {
            Messenger.Default.Send("ProductsAll");
        }

        public void showRodzajCennika()
        {
            Messenger.Default.Send("RodzajCennikaAll");
        }

        #endregion
        #region Properties

        public decimal? Cena
        {
            get
            {
                return Item.Cena;
            }
            set
            {
                if (value != Item.Cena)
                {
                    Item.Cena = value;
                    base.OnPropertyChanged(() => Cena);
                }
            }
        }
        public string NazwaCennika
        {
            get
            {
                return Item.NazwaCennika;
            }
            set
            {
                if (value != Item.NazwaCennika)
                {
                    Item.NazwaCennika = value;
                    base.OnPropertyChanged(() => NazwaCennika);
                }
            }
        }

        public DateTime? DataObowiazywaniaOd
        {
            get
            {
                return Item.DataObowiazywaniaOd;
            }
            set
            {
                if (value != Item.DataObowiazywaniaOd)
                {
                    Item.DataObowiazywaniaOd = value;
                    base.OnPropertyChanged(() => DataObowiazywaniaOd);
                }
            }
        }
        public DateTime? DataObowiazywaniaDo
        {
            get
            {
                return Item.DataObowiazywaniaDo;
            }
            set
            {
                if (value != Item.DataObowiazywaniaDo)
                {
                    Item.DataObowiazywaniaDo = value;
                    base.OnPropertyChanged(() => DataObowiazywaniaDo);
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
        public IQueryable<KeyAndValue> RodzajCennikaComboBoxItems
        {
            get
            {
                return
                    (
                        from rodzaj in Database.RodzajCennika
                        where rodzaj.CzyAktywny == true
                        select new KeyAndValue
                        {
                            Key = rodzaj.IdRodzajuCennika,
                            Value = rodzaj.NazwaRodzajuCennika 
                        }
                    ).ToList().AsQueryable();
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Database.Cennik.AddObject(Item);
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
                if (name == "Cena")
                {
                    komunikat = BusinessValidator.CheckPrice(Cena);
                }          
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Cena"] == null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
