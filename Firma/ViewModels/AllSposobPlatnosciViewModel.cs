using GalaSoft.MvvmLight.Messaging;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using Project.ViewModels.Abstract;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class AllSposobPlatnosciViewModel : AllViewModel<SposobPlatnosci>
    {
        #region Properties
        private SposobPlatnosci _ChosenSposobPlatnosci;
        public SposobPlatnosci ChosenSposobPlatnosci
        {
            get
            {
                return _ChosenSposobPlatnosci;
            }
            set
            {
                if (_ChosenSposobPlatnosci != value)
                {
                    _ChosenSposobPlatnosci = value;
                    Messenger.Default.Send(_ChosenSposobPlatnosci);
                }
            }
        }
        #endregion
        #region Konstruktor
        public AllSposobPlatnosciViewModel()
            : base("Sposoby płatności") 
        { }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<SposobPlatnosci>
            (
                // to jest zapytanie linq (obiektowa wersja SQL)
                from sposob in InvoicesEntities.SposobPlatnosci
                where sposob.CzyAktywny == true
                select sposob
            );
        }
        #endregion
        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<SposobPlatnosci>(List.OrderBy(item => item.NazwaSposobuPlatnosci));
            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<SposobPlatnosci>(List.Where(item => item.NazwaSposobuPlatnosci != null && item.NazwaSposobuPlatnosci.StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.SposobPlatnosci.First(x => x.IdSposobuPlatnosci == ChosenSposobPlatnosci.IdSposobuPlatnosci);
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
