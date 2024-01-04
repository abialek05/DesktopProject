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
using System.Windows.Documents;

namespace Project.ViewModels
{
    public class GrupaTowaruViewModel : AllViewModel<GrupaTowaru>
    {
        #region Properties
        private GrupaTowaru _ChosenGrupaTowaru;
        public GrupaTowaru ChosenGrupaTowaru
        {
            get
            {
                return _ChosenGrupaTowaru;
            }
            set
            {
                if (_ChosenGrupaTowaru != value)
                {
                    _ChosenGrupaTowaru = value;
                    Messenger.Default.Send(_ChosenGrupaTowaru);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Konstruktor
        public GrupaTowaruViewModel()
            : base("Grupy towaru")
        {
        }
        #endregion


        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<GrupaTowaru>
            (
                // to jest zapytanie linq (obiektowa wersja SQL)
                from grupaTowaru in InvoicesEntities.GrupaTowaru
                where grupaTowaru.CzyAktywna == true
                select grupaTowaru
            );           
        }
        #endregion

        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "NazwaGrupyTowaru" };
        }
        public override void Sort()
        {
            if (SortField == "NazwaGrupyTowaru")
            {
                List = new ObservableCollection<GrupaTowaru>(List.OrderBy(item => item.NazwaGrupyTowaru));
            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "NazwaGrupyTowaru" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "NazwaGrupyTowaru")
            {
                List = new ObservableCollection<GrupaTowaru>(List.Where(item => item.NazwaGrupyTowaru != null && item.NazwaGrupyTowaru.StartsWith(FindTextBox)));
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
