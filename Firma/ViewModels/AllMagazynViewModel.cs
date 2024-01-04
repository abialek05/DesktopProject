using GalaSoft.MvvmLight.Messaging;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using Project.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project.ViewModels
{
    public class AllMagazynViewModel : AllViewModel<MagazynAllView>
    {
        #region Properties
        /* private int _clickCount = 0;
         private Timer _timer;
         private void OnTimerElapsed(object state)
         {
             _clickCount = 0;
         }
         private MagazynAllView _ChosenMagazyn;
         public MagazynAllView ChosenMagazyn
         {
             get
             {
                 return _ChosenMagazyn;
             }

             set
             {
                 if (_ChosenMagazyn != value)
                 {
                     _clickCount++;
                     if (_clickCount == 1)
                     {
                         _timer = new Timer(OnTimerElapsed, null, 500, Timeout.Infinite);
                     }
                     else if (_clickCount == 2)
                     {
                         _timer.Dispose();
                         _clickCount = 0;

                         _ChosenMagazyn = value;
                         Messenger.Default.Send(_ChosenMagazyn);
                         OnRequestClose();
                     }
                 }
             }
         }*/
        private MagazynAllView _ChosenMagazyn;
        public MagazynAllView ChosenMagazyn
        {
            get
            {
                return _ChosenMagazyn;
            }
            set
            {
                if (_ChosenMagazyn != value)
                {
                    _ChosenMagazyn = value;
                    Messenger.Default.Send(_ChosenMagazyn);
                }
            }
        }

        #endregion

        #region Konstruktor
        public AllMagazynViewModel()
            : base("Magazyny")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<MagazynAllView>
            (
                // to jest zapytanie linq (obiektowa wersja SQL)
                from magazyn in InvoicesEntities.Magazyn
                where magazyn.CzyAktywny == true
                select new MagazynAllView
                { 
                    IdMagazynu = magazyn.IdMagazynu,
                    NazwaMagazynu = magazyn.NazwaMagazynu,
                    RodzajMagazynu = magazyn.RodzajMagazynu,
                    Kraj = magazyn.Kraj,
                    Miasto = magazyn.Miasto + " " + magazyn.KodPocztowy,
                    Ulica = magazyn.Ulica + " " + magazyn.NumerUlicy + "/" + magazyn.NumerBudynku
                }
            );
        }
        #endregion
        #region FindAndSort
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Rodzaj", "Kraj" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<MagazynAllView>(List.OrderBy(item => item.NazwaMagazynu));
            }
            if (SortField == "Rodzaj")
            {
                List = new ObservableCollection<MagazynAllView>(List.OrderBy(item => item.RodzajMagazynu));
            }
            if (SortField == "Kraj")
            {
                List = new ObservableCollection<MagazynAllView>(List.OrderBy(item => item.Kraj));
            }
           
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Rodzaj", "Kraj" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<MagazynAllView>(List.Where(item => item.NazwaMagazynu != null && item.NazwaMagazynu.StartsWith(FindTextBox)));
            }

            if (FindField == "Rodzaj")
            {
                List = new ObservableCollection<MagazynAllView>(List.Where(item => item.RodzajMagazynu != null && item.RodzajMagazynu.StartsWith(FindTextBox)));
            }

            if (FindField == "Kraj")
            {
                List = new ObservableCollection<MagazynAllView>(List.Where(item => item.Kraj != null && item.Kraj.StartsWith(FindTextBox)));
            }

        }

        #endregion
        #region Delete
        public override void Delete()
        {
            var value = InvoicesEntities.Magazyn.First(x => x.IdMagazynu == ChosenMagazyn.IdMagazynu);
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
