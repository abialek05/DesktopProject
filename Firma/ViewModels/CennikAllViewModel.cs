using GalaSoft.MvvmLight.Messaging;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using Project.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class CennikAllViewModel : AllViewModel<CennikForAllView>
    {

        #region Properties
        private CennikForAllView _ChosenCennik;
        public CennikForAllView ChosenCennik
        {
            get
            {
                return _ChosenCennik;
            }
            set
            {
                if (_ChosenCennik != value)
                {
                    _ChosenCennik = value;
                    Messenger.Default.Send(_ChosenCennik);
                }
            }
        }
        #endregion
        #region Konstruktor
        public CennikAllViewModel()
           : base("Cenniki")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<CennikForAllView>
                (
                    from cennik in InvoicesEntities.Cennik
                    where cennik.CzyAktywny == true
                    select new CennikForAllView
                    { 
                        IdCennika = cennik.IdCennika,
                        NazwaCennika = cennik.NazwaCennika,
                        Cena = cennik.Cena,
                        DataDataObowiazywaniaOd = cennik.DataObowiazywaniaOd,
                        DataDataObowiazywaniaDo = cennik.DataObowiazywaniaDo,
                        NazwaTowaru = cennik.Towar.NazwaTowaru
                    }                                           
                );

        }
        #endregion
        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Towar", "Cena" };
        }
        public override void Sort()
        {
            if (SortField == "Towar")
            {
                List = new ObservableCollection<CennikForAllView>(List.OrderBy(item => item.NazwaTowaru));
            }
            if (SortField == "Cena")
            {
                List = new ObservableCollection<CennikForAllView>(List.OrderBy(item => item.Cena));
            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Towar"};
        }
        public override void Find()
        {
            Load();
            if (FindField == "Towar")
            {
                List = new ObservableCollection<CennikForAllView>(List.Where(item => item.NazwaTowaru != null && item.NazwaTowaru.StartsWith(FindTextBox)));
            }   

        }

        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.Cennik.First(x => x.IdCennika == ChosenCennik.IdCennika);
            if (value != null)
            {
                value.CzyAktywny = false;
                InvoicesEntities.SaveChanges();
            }
            Load();
        }
        #endregion
    }
}
