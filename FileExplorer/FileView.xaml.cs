using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FileExplorer.Applications;

namespace FileExplorer
{
    /// <summary>
    /// Логика взаимодействия для FileView.xaml
    /// </summary>
    public partial class FileView : UserControl
    {
        public string Path { get; }

        public string Extension;


        public FileView(FileInfo file)
        { 
            
            InitializeComponent();
            FileName.Text = file.Name;
            Path = file.FullName;
            Extension = file.Extension;
            ToolTip = $"{file.Name} \n {file.CreationTime} \n {file.Attributes}";
        }


        private void FileView_OnMouseEnter(object sender, MouseEventArgs e)
        {
            UserControlB.Opacity = 0.2;
        }

        private void FileView_OnMouseLeave(object sender, MouseEventArgs e)
        {
            UserControlB.Opacity = 0;
        }

        private void FileView_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControlB.Opacity = 0.6;
        }

        public void OpenFile(Explorer explorer)
        {

            switch (Extension)
            {
                case ".txt" or ".ini" or ".dat":
                    NotePad notePad = new NotePad(Path);
                    notePad.Show();
                    break;
                case ".dir":
                    explorer.ShowDirectories(Path);
                    break;


            }
        }
    }



    public class DirectoryType : FileView
    {
        public DirectoryType(FileInfo file) : base(file)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"\Resources\foldericon.png" , UriKind.Relative);
            image.EndInit();
            FileImage.Source = image;
            Extension = ".dir";
        }
    }

    public class FileType : FileView
    {
        public FileType(FileInfo file) : base(file)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"\Resources\exeicon.png", UriKind.Relative);
            image.EndInit();
            FileImage.Source = image;
        }
    }

}
