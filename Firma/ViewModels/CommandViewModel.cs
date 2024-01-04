using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    //to jest klasa 
    public class CommandViewModel : MainViewModel
    {
        #region Własciwosci
        public string DisplayName { get; set; } //to jest nazwa przycisku w menu z lewej strony
        public ICommand Command { get; set; } //każdy przycisk zawiera komende, ktora wywoluje funkcje, ktora otwiera zakladke
        #endregion
        #region Konstruktor
        public CommandViewModel(string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("Command");
            DisplayName = displayName;
            Command = command;
        }
        #endregion
    }
}
