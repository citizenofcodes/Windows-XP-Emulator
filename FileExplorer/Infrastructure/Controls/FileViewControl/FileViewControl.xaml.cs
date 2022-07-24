using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FileExplorer.Applications;
using FileExplorer.Applications.Explorer;
using FileExplorer.Applications.NotePad;
using FileExplorer.Applications.PhotoViewer;
using FileExplorer.Infrastructure.Command;
using FileExplorer.Model;

namespace FileExplorer.View
{
    /// <summary>
    /// Логика взаимодействия для FileView.xaml
    /// </summary>
    public partial class FileView : UserControl
    {
        public FileView(FileInfo file)
        {
            InitializeComponent();
        }
    }
}