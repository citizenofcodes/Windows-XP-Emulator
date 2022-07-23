using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using FileExplorer.Applications.PhotoViewer.ViewModel;

namespace FileExplorer.Applications.PhotoViewer
{
    /// <summary>
    /// Логика взаимодействия для Images.xaml
    /// </summary>
    public partial class PhotoViewer : Window
    {
        public PhotoViewer(string path)
        {
            InitializeComponent();
            DataContext = new PhotoViewerViewModel(path);

        }


    }
}
