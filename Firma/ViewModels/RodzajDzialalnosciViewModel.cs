using GalaSoft.MvvmLight.Messaging;
using Project.Models.Entities;
using Project.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal class RodzajDzialalnosciViewModel : AllViewModel<RodzajDzialalnosci>
    {
        #region Properties
        private RodzajDzialalnosci _ChosenRodzajDzialalnosci;
        public RodzajDzialalnosci ChosenRodzajDzialalnosci
        {
            get
            {
                return _ChosenRodzajDzialalnosci;
            }
            set
            {
                if (_ChosenRodzajDzialalnosci != value)
                {
                    _ChosenRodzajDzialalnosci = value;
                    Messenger.Default.Send(_ChosenRodzajDzialalnosci);
                }
            }
        }
        #endregion
        #region Konstruktor
        public RodzajDzialalnosciViewModel()
            : base("Rodzaje działalności")
        {
        }
        #endregion


        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RodzajDzialalnosci>
            (
                // to jest zapytanie linq (obiektowa wersja SQL)
                from rodzajDzialalnosci in InvoicesEntities.RodzajDzialalnosci
                where rodzajDzialalnosci.CzyAktywny == true
                select rodzajDzialalnosci
            );
        }
        #endregion

        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "NazwaRodzajuDzialalnosci" };
        }
        public override void Sort()
        {
            if (SortField == "NazwaRodzajuDzialalnosci")
            {
                List = new ObservableCollection<RodzajDzialalnosci>(List.OrderBy(item => item.NazwaRodzajuDzialalnosci));
            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "NazwaRodzajuDzialalnosci" };
        }
        public override void Find()
        {
            if (FindField == "NazwaRodzajuDzialalnosci")
            {
                List = new ObservableCollection<RodzajDzialalnosci>(List.Where(item => item.NazwaRodzajuDzialalnosci != null && item.NazwaRodzajuDzialalnosci.StartsWith(FindTextBox)));
            }
        }

        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.RodzajDzialalnosci.First(x => x.IdRodzajuDzialalnosci == ChosenRodzajDzialalnosci.IdRodzajuDzialalnosci);
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
