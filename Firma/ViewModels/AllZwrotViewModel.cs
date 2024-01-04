using GalaSoft.MvvmLight.Messaging;
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
    public class AllZwrotViewModel : AllViewModel<ZwrotForAllView>
    {
        #region Properties
        private ZwrotForAllView _ChosenZwrot;
        public ZwrotForAllView ChosenZwrot
        {
            get
            {
                return _ChosenZwrot;
            }

            set
            {
                if (_ChosenZwrot != value)
                {
                    _ChosenZwrot = value;
                    Messenger.Default.Send(_ChosenZwrot);
                }
            }
        }
        #endregion
        #region Konstruktor
        public AllZwrotViewModel()
            : base("Zwroty")
        { 
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZwrotForAllView>
            (
                from zwrot in InvoicesEntities.Zwrot
                where zwrot.CzyAktywny == true
                select new ZwrotForAllView
                {
                    IdZwrotu = zwrot.IdZwrotu,
                    KodZwrotu = zwrot.KodZwrotu,
                    NumerFaktury = zwrot.Faktura.NumerFaktury,
                    NazwaKontrahenta = zwrot.Kontrahent.NazwaKontrahenta,
                    AdresKontrahenta = zwrot.Kontrahent.Miasto + " " + zwrot.Kontrahent.KodPocztowy,
                    NazwaTowaru = zwrot.Towar.NazwaTowaru,
                    NazwaMagazynu = zwrot.Magazyn.NazwaMagazynu,
                    AdresMagazynu = zwrot.Magazyn.Miasto + " " + zwrot.Magazyn.KodPocztowy

                }
                );
        }
        #endregion

        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "KodZwrotu", "NazwaKontrahenta", "NazwaMagazynu", "NazwaTowaru" };
        }
        public override void Sort()
        {
            if (SortField == "KodZwrotu")
            {
                List = new ObservableCollection<ZwrotForAllView>(List.OrderBy(item => item.KodZwrotu));
            }
            if (SortField == "NazwaKontrahenta")
            {
                List = new ObservableCollection<ZwrotForAllView>(List.OrderBy(item => item.NazwaKontrahenta));
            }
            if (SortField == "NazwaMagazynu")
            {
                List = new ObservableCollection<ZwrotForAllView>(List.OrderBy(item => item.NazwaMagazynu));
            }           
            if (SortField == "NazwaTowaru")
            {
                List = new ObservableCollection<ZwrotForAllView>(List.OrderBy(item => item.NazwaTowaru));
            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "KodZwrotu", "NazwaKontrahenta", "NazwaMagazynu", "NazwaTowaru" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "KodZwrotu")
            {
                List = new ObservableCollection<ZwrotForAllView>(List.Where(item => item.KodZwrotu != null && item.KodZwrotu.StartsWith(FindTextBox)));
            }

            if (FindField == "NazwaKontrahenta")
            {
                List = new ObservableCollection<ZwrotForAllView>(List.Where(item => item.NazwaKontrahenta != null && item.NazwaKontrahenta.StartsWith(FindTextBox)));
            }

            if (FindField == "NazwaMagazynu")
            {
                List = new ObservableCollection<ZwrotForAllView>(List.Where(item => item.NazwaMagazynu != null && item.NazwaMagazynu.StartsWith(FindTextBox)));
            }
            if (FindField == "NazwaTowaru")
            {
                List = new ObservableCollection<ZwrotForAllView>(List.Where(item => item.NazwaTowaru != null && item.NazwaTowaru.StartsWith(FindTextBox)));
            }

        }

        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.Zwrot.First(x => x.IdZwrotu == ChosenZwrot.IdZwrotu);
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
