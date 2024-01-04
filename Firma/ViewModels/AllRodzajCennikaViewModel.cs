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
    public class AllRodzajCennikaViewModel : AllViewModel<RodzajCennika>
    {
        #region Properties
        private RodzajCennika _ChosenRodzajCennika;
        public RodzajCennika ChosenRodzajCennika
        {
            get
            {
                return _ChosenRodzajCennika;
            }

            set
            {
                if (_ChosenRodzajCennika != value)
                {
                    _ChosenRodzajCennika = value;
                    Messenger.Default.Send(_ChosenRodzajCennika);
                }
            }
        }
        #endregion
        #region Konstruktor
        public AllRodzajCennikaViewModel()
            : base("Rodzaje cenników")
        { }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RodzajCennika>
            (
                // to jest zapytanie linq (obiektowa wersja SQL)
                from rodzaj in InvoicesEntities.RodzajCennika
                where rodzaj.CzyAktywny == true
                select rodzaj
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
                List = new ObservableCollection<RodzajCennika>(List.OrderBy(item => item.NazwaRodzajuCennika));
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
                List = new ObservableCollection<RodzajCennika>(List.Where(item => item.NazwaRodzajuCennika != null && item.NazwaRodzajuCennika.StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.RodzajCennika.First(x => x.IdRodzajuCennika == ChosenRodzajCennika.IdRodzajuCennika);
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
