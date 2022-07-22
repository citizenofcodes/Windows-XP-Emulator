using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FileExplorer.Applications.PhotoViewer
{
    /// <summary>
    /// Логика взаимодействия для Images.xaml
    /// </summary>
    public partial class Images : Window
    {
        private readonly string _imagepath;
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
