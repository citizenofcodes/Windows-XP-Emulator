using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FileExplorer.Infrastructure.Command;

namespace FileExplorer.Model
{
    internal class TaskBarItem
    {
        public ICommand MaximizeMinimuzeCommand { get; }
        public string Title { get; set; }
        public BitmapImage Image { get; set; }

        public Window Window { get; set; }

        public TaskBarItem()
        {
            MaximizeMinimuzeCommand = new Command(MaximizeMinimuze);
        }


        private void MaximizeMinimuze(object obj)
        {
            Window.WindowState = Window.WindowState == WindowState.Minimized ? WindowState.Normal : WindowState.Minimized;
        }
    }
}
