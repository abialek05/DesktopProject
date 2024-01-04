using Project.Models.Entities;
using Project.Models.Validators;
using Project.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project.ViewModels
{
    public class NewBranzaViewModel : OneViewModel<Branza>, IDataErrorInfo
    {
        #region Konstruktor
        public NewBranzaViewModel()
            : base("Branża")
        {
            Item = new Branza(); 
        }
        #endregion

        #region Properties
        // dla kazdego pola edytowalnego na interfejsie tworzymy properties
        // te propertiesy bedzieby podlaczac (bindowac) do TextBoxow na interfejsie
        public string NazwaBranzy
        {
            get
            {
                return Item.NazwaBranzy;
            }
            set
            {
                if (value != Item.NazwaBranzy)
                {
                    Item.NazwaBranzy = value;                    
                    base.OnPropertyChanged(() => NazwaBranzy);
                }
            }
        }
        public string KodBranzy
        {
            get
            {
                return Item.KodBranzy;
            }
            set
            {
                if (value != Item.KodBranzy)
                {
                    Item.KodBranzy = value;                    
                    base.OnPropertyChanged(() => KodBranzy);
                }
            }
        }
        public string Opis
        {
            get
            {
                return Item.Opis;
            }
            set
            {
                if (value != Item.Opis)
                {
                    Item.Opis = value;                    
                    base.OnPropertyChanged(() => Opis);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywna = true;
            Database.Branza.AddObject(Item);
            Database.SaveChanges();
        }

        #endregion
        #region Validation       
        public string Error
        {
            get { return null; }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "NazwaBranzy")
                {
                    komunikat = StringValidator.IsUpper(NazwaBranzy);
                }
                
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaBranzy"] == null)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
