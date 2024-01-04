using Project.Helpers;
using Project.Models.BusinessLogic;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class RaportSprzedazyWszyscyViewModel : WorkspaceViewModel
    {
        #region Properties
        public InvoicesEntities InvoicesEntities { get; set; }
        private DateTime _DataOd;
        private DateTime _DataDo;
        private decimal? _UtargWszyscy;

        public DateTime DataOd
        {
            get { return _DataOd; }
            set
            {
                if (value != _DataOd)
                    _DataOd = value;
                OnPropertyChanged(() => DataOd);
            }
        }
        public DateTime DataDo
        {
            get { return _DataDo; }
            set
            {
                if (value != _DataDo)
                    _DataDo = value;
                OnPropertyChanged(() => DataDo);
            }
        }
        public decimal? UtargWszyscy
        {
            get { return _UtargWszyscy; }
            set
            {
                if (value != _UtargWszyscy)
                    _UtargWszyscy = value;
                OnPropertyChanged(() => UtargWszyscy);
            }
        }
        private BaseCommand _ObliczWszyscyCommand;
        public ICommand ObliczWszyscyCommand
        {
            get
            {
                if (_ObliczWszyscyCommand == null)
                {
                    _ObliczWszyscyCommand = new BaseCommand(() => obliczUtargWszyscy());

                    return _ObliczWszyscyCommand;
                }
                return ObliczWszyscyCommand;

            }
        }
        public IQueryable<KeyAndValue> KontrahentComboBoxItems
        {
            get
            {
                return new KontrahentAktywne(InvoicesEntities).GetAktywniKontrahenci();
            }
        }
        #endregion
        #region Helpers
        private void obliczUtargWszyscy()
        {
            //wykorzystujemy funkcje logiki biznesowej
            UtargWszyscy = new UtargWszyscy(InvoicesEntities).WszyscyUtarg(DataOd, DataDo);
        }
        #endregion
        #region Konstruktor
        public RaportSprzedazyWszyscyViewModel()
        {
            DisplayName = "Raport";
            InvoicesEntities = new InvoicesEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            UtargWszyscy = 0;
        }
        #endregion
    }
}
