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
    public class NewGrupaTowaruViewModel : OneViewModel<GrupaTowaru>, IDataErrorInfo
    {
        #region Konstruktor
        public NewGrupaTowaruViewModel()
            : base("Grupa towaru")
        {
            Item = new GrupaTowaru();
        }
        #endregion

        #region Properties        
        public string NazwaGrupyTowaru
        {
            get
            {
                return Item.NazwaGrupyTowaru;
            }
            set
            {
                if (value != Item.NazwaGrupyTowaru)
                {
                    Item.NazwaGrupyTowaru = value;
                    base.OnPropertyChanged(() => NazwaGrupyTowaru);
                }
            }
        }
        public string Kod
        {
            get
            {
                return Item.Kod;
            }
            set
            {
                if (value != Item.Kod)
                {
                    Item.Kod = value;
                    base.OnPropertyChanged(() => Kod);
                }
            }
        }
            #endregion

            #region Save
        public override void Save()
        {
            Item.CzyAktywna = true;
            Database.GrupaTowaru.AddObject(Item);
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
                if (name == "NazwaGrupyTowaru")
                {
                    komunikat = StringValidator.IsUpper(NazwaGrupyTowaru);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaGrupyTowaru"] == null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
