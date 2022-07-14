using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FileExplorer.Applications
{
    /// <summary>
    /// Логика взаимодействия для Images.xaml
    /// </summary>
    public partial class Images : Window
    {
        private string _imagepath;
        public Images(string Path)
        {
            InitializeComponent();
            _imagepath = Path;
            LoadImage();
            
            FileInfo fileInfo = new FileInfo(Path);
            Title = fileInfo.Name;
            
        }

        private void LoadImage()
        {

            BitmapImage image = new BitmapImage(new Uri(_imagepath, UriKind.Absolute));
            

            ImageViewer.Source = image;
        }

    }
}
