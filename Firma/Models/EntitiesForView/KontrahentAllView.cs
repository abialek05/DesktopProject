using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.EntitiesForView
{
    public class KontrahentAllView
    {
        #region Properties
        public int IdKontrahenta { get; set;  }
        public string NazwaKontrahenta { get; set;  }
        public string KodKontrahenta { get; set; }
        public string RodzajDzialalnosciNazwa { get; set; } 
        public string BranzaNazwa { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string PESEL { get; set; }

        public string Adres { get; set; }

        #endregion
    }
}
