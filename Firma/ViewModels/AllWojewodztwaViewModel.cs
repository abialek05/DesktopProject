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
    public class AllWojewodztwaViewModel : AllViewModel<Wojewodztwa>
    {
        #region Konstruktor
        public AllWojewodztwaViewModel()
            : base("Województwa")
        {
        }
        #endregion


        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Wojewodztwa>
            (
                // to jest zapytanie linq (obiektowa wersja SQL)
                from wojewodztwo in InvoicesEntities.Wojewodztwa
                select wojewodztwo
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
                List = new ObservableCollection<Wojewodztwa>(List.OrderBy(item => item.Nazwa));
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
                List = new ObservableCollection<Wojewodztwa>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Delete
        public override void Delete()
        {           
        }
        #endregion
    }
}
