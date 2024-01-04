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
    public class AllClientsViewModel : AllViewModel<KontrahentAllView>
    {
        #region Properties
        private KontrahentAllView _ChosenClient;
        public KontrahentAllView ChosenClient
        {
            get
            {
                return _ChosenClient;
            }
            set
            {
                if (_ChosenClient != value)
                {
                    _ChosenClient = value;
                    Messenger.Default.Send(_ChosenClient);
                }
            }
        }
        #endregion


        #region Konstruktor
        public AllClientsViewModel()
           : base("Kontrahenci")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KontrahentAllView>
                (
                    from kontrahent in InvoicesEntities.Kontrahent
                    where kontrahent.CzyAktywny == true
                    select new KontrahentAllView
                    {
                        IdKontrahenta = kontrahent.IdKontrahenta,
                        NazwaKontrahenta = kontrahent.NazwaKontrahenta,
                        KodKontrahenta = kontrahent.KodKontrahenta,
                        RodzajDzialalnosciNazwa = kontrahent.RodzajDzialalnosci.NazwaRodzajuDzialalnosci,
                        BranzaNazwa = kontrahent.Branza.NazwaBranzy,
                        NIP = kontrahent.NIP,
                        REGON = kontrahent.REGON,
                        PESEL = kontrahent.PESEL,

                    }
                );

        }
        #endregion

        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "NazwaKontrahenta", "KodKontrahenta", "RodzajDzialalnosciNazwa" };
        }
        public override void Sort()
        {
            if (SortField == "NazwaKontrahenta")
            {
                List = new ObservableCollection<KontrahentAllView>(List.OrderBy(item => item.NazwaKontrahenta));
            }
            if (SortField == "KodKontrahenta")
            {
                List = new ObservableCollection<KontrahentAllView>(List.OrderBy(item => item.KodKontrahenta));
            }
            if (SortField == "RodzajDzialalnosciNazwa")
            {
                List = new ObservableCollection<KontrahentAllView>(List.OrderBy(item => item.RodzajDzialalnosciNazwa));
            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "NazwaKontrahenta", "KodKontrahenta", "RodzajDzialalnosciNazwa" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "NazwaKontrahenta")
            {                
                List = new ObservableCollection<KontrahentAllView>(List.Where(item => item.NazwaKontrahenta != null && item.NazwaKontrahenta.StartsWith(FindTextBox)));                
            }
            
            if (FindField == "KodKontrahenta")
            {
                List = new ObservableCollection<KontrahentAllView>(List.Where(item => item.KodKontrahenta != null && item.KodKontrahenta.StartsWith(FindTextBox)));
            }

            if (FindField == "RodzajDzialalnosciNazwa")
            {
                List = new ObservableCollection<KontrahentAllView>(List.Where(item => item.RodzajDzialalnosciNazwa != null && item.RodzajDzialalnosciNazwa.StartsWith(FindTextBox)));
            }

        }

        #endregion
        #region Delete
        public override void Delete()
        {
            var kontrahent = InvoicesEntities.Kontrahent.First(x => x.IdKontrahenta == ChosenClient.IdKontrahenta);
            if (kontrahent != null)
            {
                kontrahent.CzyAktywny = false;
                InvoicesEntities.SaveChanges();
            }
            Load();
        }
        #endregion
    }
}
