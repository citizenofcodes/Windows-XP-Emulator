using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileExplorer.Infrastructure.Command
{
    internal class CloseWindowCommand:ICommand
    {
        public static readonly ICommand instance = new CloseWindowCommand();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


        public bool CanExecute(object parameter)
        {
            return (parameter is Window);
        }

        public void Execute(object parameter)
        {
            Window win;
            win = (Window)parameter;
            win.Close();
        }   
    }
}
