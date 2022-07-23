using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FileExplorer.Applications.PhotoViewer.ViewModel
{
    
    internal class PhotoViewerViewModel
    {
        private BitmapImage _image;

        public BitmapImage image
        {
            get => _image;
            set => _image = value;
        }

        public string Title { get; set; }
        public PhotoViewerViewModel(string imagePath)
        {
            Title = new FileInfo(imagePath).Name;

            image = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
        }

        public PhotoViewerViewModel()
        {
            
        }
    }
}
