using GalaSoft.MvvmLight.Messaging;
using Project.Helpers;
using Project.Models;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels.Abstract
{
    public abstract class AllViewModel<T> : WorkspaceViewModel 
    {
        #region Fields

        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }

        private readonly InvoicesEntities invoicesEntities;
        public InvoicesEntities InvoicesEntities
        {
            get
            {
                return invoicesEntities;
            }
        }

        private BaseCommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new BaseCommand(() => Delete());
                }
                return _DeleteCommand;
            }
        }

        // to jest komenda do zaladowania towaru
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load()); //pusta wywoluje load
                }
                return _LoadCommand;
            }
        }
        // w tym obiekcie beda wszystkie towary
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
               if (_List == null) //jak lista jest pusta to wywolujemy load
                    Load();
               
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion

        #region Konstruktor
        public AllViewModel(string displayName)
        {
            base.DisplayName = displayName;
            this.invoicesEntities = new InvoicesEntities();
        }
        #endregion

        #region Helpers
        public abstract void Load();

        public abstract void Delete();
        private void add()
        {
             Messenger.Default.Send(Regex.Replace(DisplayName, @"\s+", "") + "Add");
           // Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion

        // to jest komenda, ktora zostanie podpieta pod przycisk Sortuj
        //wywola ona funkcje Sort()
        #region Sort

        public BaseCommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }

        public abstract void Sort();

        // to jest pole do przechowywania wyboru tego, po czym będziemy sortować
        public string SortField { get; set; }

        //to jest properties, ktory wypelnia opcje wyboru w combo boxie na bazie funkcji GetComboBoxSortList
        public List<string> SortComboBoxItems
        {
            get
            {
                return GetComboBoxSortList();
            }
        }

        public abstract List<string> GetComboBoxSortList();


        #endregion

        // komenda, któa zostanie podpięta pod przycisk Filtruj
        // wywola ona funkcje Find()

        #region Find
        private BaseCommand _FindCommand;
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }

        public abstract void Find();

        //to jest wlasciwosc, w ktorej zostanie zapisany wybór pola, po którym będziemy wyszukiwać

        public string FindField { get; set; }

        //to jest wlasciwosc, w ktorej zostaniee wpisany poczatek frazy wyszukujacej i ktora zostanie podpieta pod TextBox
        public string FindTextBox { get; set; }

        public List<string> FindComboBoxItems
        {
            get
            {
                return GetComboBoxFindList();
            }
        }

        public abstract List<string> GetComboBoxFindList();

        #endregion
    }
}
