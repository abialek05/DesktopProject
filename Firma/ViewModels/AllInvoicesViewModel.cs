using GalaSoft.MvvmLight.Messaging;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using Project.ViewModels.Abstract;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class AllInvoicesViewModel : AllViewModel<InvoicesAllView>
    {
        #region Properties
        private InvoicesAllView _ChosenInvoice;
        public InvoicesAllView ChosenInvoice
        {
            get
            {
                return _ChosenInvoice;
            }
            set
            {
                if (_ChosenInvoice != value)
                {
                    _ChosenInvoice = value;
                    Messenger.Default.Send(_ChosenInvoice);
                }
            }
        }
        #endregion

        #region Konstruktor
        public AllInvoicesViewModel()
            : base("Faktury")

        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<InvoicesAllView>
            (

                from invoice in InvoicesEntities.Faktura
                where invoice.CzyAktywna == true
                select new InvoicesAllView
                {
                    IdFaktury = invoice.IdFaktury,
                    NumerFaktury = invoice.NumerFaktury,

                    KontrahentNazwa = invoice.Kontrahent.NazwaKontrahenta,
                    KontrahentNIP = invoice.Kontrahent.NIP,

                    KategoriaFakturyNazwa = invoice.KategoriaFaktury.NazwaKategorii,

                    DataWystawienia = invoice.DataWystawienia,
                    DataSprzedazy = invoice.DataSprzedazy,

                    TowarNazwaTowaru = invoice.Towar.NazwaTowaru,
                    Kwota = invoice.Kwota,
                    IloscTowaru = invoice.IloscTowaru,

                    SposobPlatnosciNazwa = invoice.SposobPlatnosci.NazwaSposobuPlatnosci,
                    TerminPlatnosci = invoice.TerminPlatnosci,


                }
                );
        }
        #endregion

        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Numer", "Kategoria", "Kwota", "Towar", "DataWystawienia", "DataSprzedazy" };
        }
        public override void Sort()
        {
            if (SortField == "Numer")
            {
                List = new ObservableCollection<InvoicesAllView>(List.OrderBy(item => item.NumerFaktury));
            }
            if (SortField == "Kategoria")
            {
                List = new ObservableCollection<InvoicesAllView>(List.OrderBy(item => item.KategoriaFakturyNazwa));
            }
            if (SortField == "Kwota")
            {
                List = new ObservableCollection<InvoicesAllView>(List.OrderBy(item => item.Kwota));
            }
            if (SortField == "Towar")
            {
                List = new ObservableCollection<InvoicesAllView>(List.OrderBy(item => item.TowarNazwaTowaru));
            }
            if (SortField == "DataWystawienia")
            {
                List = new ObservableCollection<InvoicesAllView>(List.OrderBy(item => item.DataWystawienia));
            }
            if (SortField == "DataSprzedazy")
            {
                List = new ObservableCollection<InvoicesAllView>(List.OrderBy(item => item.DataSprzedazy));
            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Numer", "Kontrahent", "Kategoria" };
        }
        public override void Find()
        {
            Load();

            if (FindField == "Numer")
            {
                List = new ObservableCollection<InvoicesAllView>(List.Where(item => item.NumerFaktury != null && item.NumerFaktury.StartsWith(FindTextBox)));
            }

            if (FindField == "Kontrahent")
            {
                List = new ObservableCollection<InvoicesAllView>(List.Where(item => item.KontrahentNazwa != null && item.KontrahentNazwa.StartsWith(FindTextBox)));
            }

            if (FindField == "Kategoria")
            {
                List = new ObservableCollection<InvoicesAllView>(List.Where(item => item.KategoriaFakturyNazwa != null && item.KategoriaFakturyNazwa.StartsWith(FindTextBox)));
            }

        }

        #endregion\
        #region Delete
        public override void Delete()
        {
            var faktura = InvoicesEntities.Faktura.First(x => x.IdFaktury == ChosenInvoice.IdFaktury);
            if (faktura != null)
            {
                faktura.CzyAktywna = false;
                InvoicesEntities.SaveChanges();
            }
            Load();
        }
        #endregion
    }
}
