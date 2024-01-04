using Project.Helpers;
using Project.Models;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModels.Abstract
{
    public abstract class OneViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        public InvoicesEntities Database { get; set; }
        // tu jest nasz dodawany towar
        public T Item { get; set; }

        #endregion
        #region Konstruktor
        public OneViewModel(string displayName)
        {
            base.DisplayName = displayName;//tu ustawiamy nazwę zakładki
            Database = new InvoicesEntities();

        }
        #endregion

        #region Command
        // to jest komenda, ktora zostanie podpieta (zbindowana) z przyciskiem Zapisz i zamknij. Komenda ta wywola funkcje saveAndClose()
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveAndCloseCommand;
            }
        }

        private BaseCommand _AnulujCommand;
        public ICommand AnulujCommand
        {
            get
            {
                if (_AnulujCommand == null)
                {
                    _AnulujCommand = new BaseCommand(() => anuluj());
                }
                return _AnulujCommand;
            }
        }

        public void anuluj()
        {
            base.OnRequestClose();
        }

        #endregion

        #region Save
        public abstract void Save();

        private void saveAndClose()
        {
            if (IsValid())
            {
                // zapisuje towar
                Save();
                // zamyka zakladke
                base.OnRequestClose();
            }
            else
            {
                MessageBox.Show("Uzupełnij wszystkie dane!");
            }
        }


        #endregion
        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion

    }
}
