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
    internal class KategoriaFakturyViewModel : AllViewModel<KategoriaFaktury>
    {
        
        #region Properties
        private ZamowieniaForAllView _ChosenKategoriaFaktury;
        public ZamowieniaForAllView ChosenKategoriaFaktury
        {
            get
            {
                return _ChosenKategoriaFaktury;
            }

            set
            {
                if (_ChosenKategoriaFaktury != value)
                {
                    _ChosenKategoriaFaktury = value;
                    Messenger.Default.Send(_ChosenKategoriaFaktury);

                }
            }
        }
        #endregion
        #region Konstruktor
        public KategoriaFakturyViewModel()
            : base("Kategorie faktur")
        {
        }
        #endregion


        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KategoriaFaktury>
            (

                // to jest zapytanie linq (obiektowa wersja SQL)
                from kategoriaFaktury in InvoicesEntities.KategoriaFaktury
                where kategoriaFaktury.CzyAktywna == true
                select kategoriaFaktury
            );
        }
        #endregion

        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa kategorii" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa kategorii")
            {
                List = new ObservableCollection<KategoriaFaktury>(List.OrderBy(item => item.NazwaKategorii));
            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa kategorii" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa kategorii")
            {
                List = new ObservableCollection<KategoriaFaktury>(List.Where(item => item.NazwaKategorii != null && item.NazwaKategorii.StartsWith(FindTextBox)));
            }
        }

        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.KategoriaFaktury.First(x => x.IdKategoriiFaktury == ChosenKategoriaFaktury.IdZamowienia);
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
