using Project.Helpers;
using Project.Models.BusinessLogic;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class TowaryWystawioneRaportViewModel : WorkspaceViewModel
    {
        #region Properties
        public InvoicesEntities InvoicesEntities { get; set; }
        private DateTime _DataOd;
        private DateTime _DataDo;
        private IEnumerable<object> _TowaryWystawione;
         public List<string> Result { get; set; }

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
        public IEnumerable<object> TowaryWystawione
        {
            get 
            {
                return _TowaryWystawione;
            }
            set
            {
                if (value != _TowaryWystawione)
                    _TowaryWystawione = value;
                OnPropertyChanged(() => TowaryWystawione);
            }            
        }
        private BaseCommand _ShowCommand;
        public ICommand ShowCommand
        {
            get
            {
                if (_ShowCommand == null)
                {
                    _ShowCommand = new BaseCommand(() => showTowaryWystawione());

                    return _ShowCommand;
                }
                return _ShowCommand;
            }
        }
        #endregion
        #region Helpers
        private void showTowaryWystawione()
        {
            //wykorzystujemy funkcje logiki biznesowej
            TowaryWystawione = new TowaryWystawione(InvoicesEntities).WystawioneTowary(DataOd, DataDo);
        }
        #endregion
        #region Konstruktor
        public TowaryWystawioneRaportViewModel()
        {
            base.DisplayName = "Raport";
            InvoicesEntities = new InvoicesEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            TowaryWystawione = null;
        }
        #endregion
    }
}
