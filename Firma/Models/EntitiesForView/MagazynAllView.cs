using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.EntitiesForView
{
    public class MagazynAllView
    {
        
        #region Properties
        public int IdMagazynu { get; set; }
        public string NazwaMagazynu { get; set; }
        public string RodzajMagazynu { get; set; }

        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }

        #endregion
    

    }
}
