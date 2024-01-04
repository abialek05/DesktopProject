using Project.Helpers;
using Project.Models.Entities;
using Project.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project.Models.BusinessLogic;

namespace Project.ViewModels
{
    public class RaportSprzedazyKontrahentViewModel : WorkspaceViewModel
    {
        #region Properties
        public InvoicesEntities InvoicesEntities { get; set; }
        private int _IdKontrahenta;
        private DateTime _DataOd;
        private DateTime _DataDo;
        private decimal? _UtargKontrahent;

        public int IdKontrahenta
        {
            get { return _IdKontrahenta; }
            set
            {
                if (value != _IdKontrahenta)
                    _IdKontrahenta = value;
                OnPropertyChanged(() => IdKontrahenta);
            }
        }
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
        public decimal? UtargKontrahent
        {
            get { return _UtargKontrahent; }
            set
            {
                if (value != _UtargKontrahent)
                    _UtargKontrahent = value;
                OnPropertyChanged(() => UtargKontrahent);
            }
        }
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => obliczUtargKontrahent());

                    return _ObliczCommand;
                }
                return ObliczCommand;

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
        private void obliczUtargKontrahent()
        {
            //wykorzystujemy funkcje logiki biznesowej
            UtargKontrahent = new UtargKontrahent(InvoicesEntities).KontrahentUtarg(IdKontrahenta, DataOd, DataDo);
        }
        #endregion
        #region Konstruktor
        public RaportSprzedazyKontrahentViewModel()
        {
            base.DisplayName = "Raport";
            InvoicesEntities = new InvoicesEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            UtargKontrahent = 0;
        }
        #endregion
    }
}
