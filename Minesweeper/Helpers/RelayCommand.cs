using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Minesweeper.Helpers
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action DoWork;

        public RelayCommand(Action TypeWork)
        {
            DoWork = TypeWork;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DoWork();
        }
    }
}
