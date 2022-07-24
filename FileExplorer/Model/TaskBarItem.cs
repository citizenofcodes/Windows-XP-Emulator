using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FileExplorer.Model
{
    internal class TaskBarItem
    {
        public string Title { get; set; }
        public BitmapImage Image { get; set; }

        public Window Window { get; set; }
    }
}
