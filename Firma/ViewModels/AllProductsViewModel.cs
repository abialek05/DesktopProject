using GalaSoft.MvvmLight.Messaging;
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
    public class AllProductsViewModel : AllViewModel<TowarAllView>
    {
        #region Properties
        private TowarAllView _ChosenProduct;
        public TowarAllView ChosenProduct
        {
            get
            {
                return _ChosenProduct;
            }

            set
            {
                if (_ChosenProduct != value)
                {
                    _ChosenProduct = value;
                    Messenger.Default.Send(_ChosenProduct);
                }
            }
        }
        #endregion

        #region Konstruktor
        public AllProductsViewModel()
             : base("Wszystkie towary")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TowarAllView>
            (
                from towar in InvoicesEntities.Towar
                where towar.CzyAktywny == true
                select new TowarAllView
                {
                    IdTowaru = towar.IdTowaru,
                    KodTowaru = towar.KodTowaru,
                    NazwaTowaru = towar.NazwaTowaru,
                    TypTowaruNazwa = towar.TypTowaru.NazwaTypu,
                    KodEAN = towar.KodEAN,
                    GrupaTowaruNazwa = towar.GrupaTowaru.NazwaGrupyTowaru,
                    StawkaVatSprzedazy = towar.StawkaVatSprzedazy,
                    StawkaVatZakupu = towar.StawkaVatZakupu,
                }
            );
        }
        #endregion
        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Kod", "Nazwa", "Typ" };
        }
        public override void Sort()
        {
            if (SortField == "Kod")
            {
                List = new ObservableCollection<TowarAllView>(List.OrderBy(item => item.KodTowaru));
            }
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<TowarAllView>(List.OrderBy(item => item.NazwaTowaru));
            }
            if (SortField == "Typ")
            {
                List = new ObservableCollection<TowarAllView>(List.OrderBy(item => item.TypTowaruNazwa));
            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Kod", "Nazwa", "Typ" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Kod")
            {
                List = new ObservableCollection<TowarAllView>(List.Where(item => item.KodTowaru != null && item.KodTowaru.StartsWith(FindTextBox)));
            }

            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<TowarAllView>(List.Where(item => item.NazwaTowaru != null && item.NazwaTowaru.StartsWith(FindTextBox)));
            }

            if (FindField == "Typ")
            {
                List = new ObservableCollection<TowarAllView>(List.Where(item => item.TypTowaruNazwa != null && item.TypTowaruNazwa.StartsWith(FindTextBox)));
            }

        }

        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.Towar.First(x => x.IdTowaru == ChosenProduct.IdTowaru);
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

