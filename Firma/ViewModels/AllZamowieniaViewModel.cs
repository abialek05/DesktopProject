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
    public class AllZamowieniaViewModel : AllViewModel<ZamowieniaForAllView>
    {
        #region Properties
        private ZamowieniaForAllView _ChosenZamowienie;
        public ZamowieniaForAllView ChosenZamowienie
        {
            get
            {
                return _ChosenZamowienie;
            }

            set
            {
                if (_ChosenZamowienie != value)
                {
                    _ChosenZamowienie = value;
                    Messenger.Default.Send(_ChosenZamowienie);
                    
                }
            }
        }
        #endregion
        public AllZamowieniaViewModel()
                    : base("Zamówienia")
        {
        }
        public override void Load()
        {
            List = new ObservableCollection<ZamowieniaForAllView>
                (
                from zamowienie in InvoicesEntities.Zamowienie
                where zamowienie.CzyAktywne == true
                select new ZamowieniaForAllView
                {
                    IdZamowienia = zamowienie.IdZamowienia,
                    NumerZamowienia = zamowienie.NumerZamowienia,
                    DataZlozenia = zamowienie.DataZlozenia,
                    DataRealizacji = zamowienie.DataRealizacji,
                    NazwaKontrahenta = zamowienie.Kontrahent.NazwaKontrahenta,
                    NazwaTowaru = zamowienie.Towar.NazwaTowaru,
                    NazwaMagazynu = zamowienie.Magazyn.NazwaMagazynu,
                    Wartosc = zamowienie.Wartosc,
                    CzyOplacone = zamowienie.CzyOplacone,
                    CzyPotwierdzone = zamowienie.CzyPotwierdzone
                }
                );
        }

        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "NumerZamowienia", "DataZlozenia", "DataRealizacji", "NazwaKontrahenta" };
        }
        public override void Sort()
        {
            if (SortField == "NumerZamowienia")
            {
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.NumerZamowienia));
            }
            if (SortField == "DataZlozenia")
            {
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.DataZlozenia));
            }
            if (SortField == "DataRealizacji")
            {
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.DataRealizacji));
            }
            if (SortField == "NazwaKontrahenta")
            {
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.NazwaKontrahenta));
            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "NumerZamowienia", "NazwaKontrahenta", "NazwaTowaru" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "NumerZamowienia")
            {
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.NumerZamowienia != null && item.NumerZamowienia.StartsWith(FindTextBox)));
            }

            if (FindField == "NazwaKontrahenta")
            {
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.NazwaKontrahenta != null && item.NazwaKontrahenta.StartsWith(FindTextBox)));
            }

            if (FindField == "NazwaTowaru")
            {
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.NazwaTowaru != null && item.NazwaTowaru.StartsWith(FindTextBox)));
            }

        }

        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.Zamowienie.First(x => x.IdZamowienia == ChosenZamowienie.IdZamowienia);
            if (value != null)
            {
                value.CzyAktywne = false;
                InvoicesEntities.SaveChanges();
            }
            Load();
        }
        #endregion

    }
}
