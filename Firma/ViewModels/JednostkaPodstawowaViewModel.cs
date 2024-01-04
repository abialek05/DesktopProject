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
    public class JednostkaPodstawowaViewModel : AllViewModel<JednostkaPodstawowa>
    {
        #region Properties
        private JednostkaPodstawowa _ChosenJednostkaPodstawowa;
        public JednostkaPodstawowa ChosenJednostkaPodstawowa
        {
            get
            {
                return _ChosenJednostkaPodstawowa;
            }
            set
            {
                if (_ChosenJednostkaPodstawowa != value)
                {
                    _ChosenJednostkaPodstawowa = value;
                    Messenger.Default.Send(_ChosenJednostkaPodstawowa);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Konstruktor
        public JednostkaPodstawowaViewModel()
            : base("Jednostki podstawowe")
        {
        }
        #endregion


        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<JednostkaPodstawowa>
            (
                // to jest zapytanie linq (obiektowa wersja SQL)
                from jednostkaPodstawowa in InvoicesEntities.JednostkaPodstawowa
                where jednostkaPodstawowa.CzyAktywny == true
                select jednostkaPodstawowa
            );
        }
        #endregion

        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "NazwaJednostki" };
        }
        public override void Sort()
        {
            if (SortField == "NazwaJednostki")
            {
                List = new ObservableCollection<JednostkaPodstawowa>(List.OrderBy(item => item.NazwaJednostki));
            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "NazwaJednostki" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "NazwaJednostki")
            {
                List = new ObservableCollection<JednostkaPodstawowa>(List.Where(item => item.NazwaJednostki != null && item.NazwaJednostki.StartsWith(FindTextBox)));
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
