using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Validators
{
    //to jest klasa, która umożliwia walidację Stringów
    public class StringValidator : Validator
    {
        // to jest funkcja, ktora sprawdza czy wartosc podana jako parametr zaczyna sie od duzej litery
        // jezeli zaczyna sie od duzej litery, to zwraca nulla
        // jezeli sie nie zaczyna od duzej litery, to zwraca komunikat bledu

        public static string IsUpper(string value)
        {
            try
            {
                if (!char.IsUpper(value, 0))
                {
                    return "Rozpocznij dużą literą";
                    
                }
                return null;
            }
            catch (Exception)
            {
            }
            return null;
        }
        public static string IsNIP(string value)
        {
            try
            {
                if (value != null)
                {
                    if (value.Length > 10)
                    {
                        return "Niepoprawny kod NIP";
                    }
                }
                return null;
            }
            catch (Exception)
            {
            }
            return null;
        }
        public static string IsREGON(string value)
        {
            try
            {
                if (value != null)
                {
                    if (value.Length > 14)
                    {
                        return "Niepoprawny kod REGON";
                    }
                }
                return null;
            }
            catch (Exception)
            {
            }
            return null;
        }
        public static string IsPESEL(string value)
        {
            try            
            {
                    if (value != null)
                    {
                        if (value.Length > 11)
                        {
                            return "Niepoprawny kod PESEL";
                        }
                    }
                return null;
            }
            catch (Exception)
            {
            }
            return null;
        }

        public static string IsKodPocztowy(string value)
        {
            try
            {
                if (value != null)
                {
                    if (value.Length > 6 || !value[2].Equals('-'))
                    {
                        return "Niepoprawny format kodu pocztowego";
                    }
                }
                return null;
            }
            catch (Exception)
            {
            }
            return null;

        }
        public static string CheckEan(string value)
        {
            try
            {
                if (value != null)
                {
                    if (value.Length > 13)
                    {
                        return "Kod EAN nie może być dłuższy niż 13 znaków";
                    }
                }
                return null;
            }
            catch (Exception)
            {
            }
            return null;

        }

        public static string IsEmail(string value)
        {
            try
            {
                if (value != null)
                {
                    if (!value.Contains("@"))
                    {
                        return "Niepoprawny format e-mail";
                    }
                }
                return null;
            }
            catch (Exception)
            {
            }
            return null;

        }

    }
}
