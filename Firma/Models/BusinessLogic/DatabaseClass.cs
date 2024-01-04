using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.BusinessLogic
{
    public class DatabaseClass
    {
        #region Entities
        public InvoicesEntities InvoicesEntities { get; set; }
        #endregion
        #region Konstruktor
        public DatabaseClass(InvoicesEntities invoicesEntities) 
        {
            this.InvoicesEntities = invoicesEntities;
        }
        #endregion

    }
}
