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
    internal class BranzaViewModel : AllViewModel<Branza>
    {
        #region Properties
        private Branza _ChosenBranza;
        public Branza ChosenBranza
        {
            get
            {
                return _ChosenBranza;
            }
            set
            {
                if (_ChosenBranza != value)
                {
                    _ChosenBranza = value;
                    Messenger.Default.Send(_ChosenBranza);
                }
            }
        }
        #endregion
        
        #region Konstruktor
        public BranzaViewModel()
            : base("Branże")
        {
        }
        #endregion


        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Branza>
            (
                // to jest zapytanie linq (obiektowa wersja SQL)
                from branza in InvoicesEntities.Branza
                where branza.CzyAktywna == true
                select branza
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
                List = new ObservableCollection<Branza>(List.OrderBy(item => item.NazwaBranzy));
            }           

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<Branza>(List.Where(item => item.NazwaBranzy != null && item.NazwaBranzy.StartsWith(FindTextBox)));
            }
        }
        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.Branza.First(x => x.IdBranzy == ChosenBranza.IdBranzy);
            if (value != null)
            {
                value.CzyAktywna = false;
                InvoicesEntities.SaveChanges();
            }
            Load();
        }
        #endregion

    }
}
