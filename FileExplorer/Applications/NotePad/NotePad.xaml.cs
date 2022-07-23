using System.IO;
using System.Windows;
using System.Windows.Controls;
using FileExplorer.Applications.NotePad.ViewModel;

namespace FileExplorer.Applications.NotePad
{
    /// <summary>
    /// Логика взаимодействия для NotePad.xaml
    /// </summary>
    public partial class NotePad : Window
    {

        public NotePad()
        {
            InitializeComponent();
        }

        public NotePad(string path)
        {
            InitializeComponent();
            DataContext = new NotePadViewModel(path);

        }



    }
}
