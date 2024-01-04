using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Validators
{
    public class BusinessValidator : Validator
    {
        public static string CheckVat(decimal? value)
        {
            if (value < 0 || value > 100)
            {
                return "VAT powinien znajdować się w przedziale od 0 do 100";
            }
            return null;
        }

        public static string CheckPrice(decimal? price)
        {
            if (price < 0 || price == 0)
            {
                return "Cena musi być większa od zera";
            }
            return null;
        }
    }
}
