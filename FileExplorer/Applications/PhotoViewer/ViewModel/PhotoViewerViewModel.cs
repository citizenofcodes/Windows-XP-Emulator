using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using FileExplorer.Services;
using FileExplorer.ViewModel;
using Microsoft.Extensions.DependencyInjection;

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

        public void OnClosing(object sender, CancelEventArgs args) => App.AppHost.Services.GetRequiredService<ITaskBarService>().DeleteTaskItem((Window)sender);
    }
}
