using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using FileExplorer.ViewModel;

namespace FileExplorer.Applications.PhotoViewer.ViewModel
{
    
    internal class PhotoViewerViewModel:BaseVm
    {
        private BitmapImage _image;

        public BitmapImage image
        {
            get => _image;
            set => _image = value;
        }

        public string Title { get; set; }

        public string ImagePath { get; set; }
        public PhotoViewerViewModel()
        {
            
        }


        public void SetImagePath(string imagePath)
        {
            if (imagePath != null)
            {
                ImagePath = imagePath;

                Title = new FileInfo(ImagePath).Name;

                image = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));

                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(image));
            }

           
        }
    }
}
