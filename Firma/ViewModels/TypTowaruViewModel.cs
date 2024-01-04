using GalaSoft.MvvmLight.Messaging;
using Project.Models.Entities;
using Project.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Project.ViewModels
{
    public class TypTowaruViewModel : AllViewModel<TypTowaru>
    {
        #region Properties
        private TypTowaru _ChosenTypTowaru;
        public TypTowaru ChosenTypTowaru
        {
            get
            {
                return _ChosenTypTowaru;
            }
            set
            {
                if (_ChosenTypTowaru != value)
                {
                    _ChosenTypTowaru = value;
                    Messenger.Default.Send(_ChosenTypTowaru);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Konstruktor
        public TypTowaruViewModel()
            : base("Typy towaru")
        {
        }
        #endregion


        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypTowaru>
            (
                // to jest zapytanie linq (obiektowa wersja SQL)
                from typTowaru in InvoicesEntities.TypTowaru    
                where typTowaru.CzyAktywny == true
                select typTowaru
            );
        }
        #endregion
        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "NazwaTypu" };
        }
        public override void Sort()
        {
            if (SortField == "NazwaTypu")
            {
                List = new ObservableCollection<TypTowaru>(List.OrderBy(item => item.NazwaTypu));
            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "NazwaTypu" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "NazwaTypu")
            {
                List = new ObservableCollection<TypTowaru>(List.Where(item => item.NazwaTypu != null && item.NazwaTypu.StartsWith(FindTextBox)));
            }
        }

        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.TypTowaru.First(x => x.IdTypuTowaru == ChosenTypTowaru.IdTypuTowaru);
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

