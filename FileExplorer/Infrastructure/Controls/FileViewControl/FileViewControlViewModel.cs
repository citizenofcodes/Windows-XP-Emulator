using FileExplorer.Applications.Explorer;
using FileExplorer.Applications.NotePad;
using FileExplorer.Applications.PhotoViewer;
using FileExplorer.Infrastructure.Command;
using FileExplorer.ViewModel;
using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FileExplorer.View
{
    internal class FileViewControlViewModel : BaseVm
    {

        private string _extension;

        private Explorer _explorer;
        public string Path { get; }
        public string Tooltip { get; }
        public string FileName { get; }
        public BitmapImage Image { get; set; }
        public ICommand OpenFileCommand { get; }

        public FileViewControlViewModel()
        {

        }
        public FileViewControlViewModel(FileInfo file)
        {

            FileName = file.Name;
            Path = file.FullName;

            _extension = file.Attributes.ToString().Contains("Directory") ? ".dir" : file.Extension.ToLower();

            Tooltip = $"{file.Name} \n {file.CreationTime} \n {file.Attributes}";

            PickIcon();


            OpenFileCommand = new Command(CommandOpenFile);

        }


        private void CommandOpenFile(object window)
        {
            switch (_extension)
            {
                case ".txt" or ".ini" or ".dat":
                    NotePad notePad = new NotePad(Path);
                    notePad.Show();
                    break;
                case ".img" or ".png" or ".jgeg":
                    PhotoViewer photoViewer = new PhotoViewer(Path);
                    photoViewer.Show();
                    break;
                case ".dir":
                    if (IsDesktop(window))
                    {
                        _explorer = new Explorer(this);
                        _explorer.Show();
                    }

                    else
                    {
                        _explorer = window as Explorer;
                        if (_explorer != null) _explorer.viewModel.CurrentPath = Path;
                    }
                    break;

            }
        }

        private void PickIcon()
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            switch (_extension)
            {
                case ".dir":
                    image.UriSource = new Uri(@"\Resources\foldericon.png", UriKind.Relative);
                    break;
                case ".img" or ".png" or ".jpeg":
                    image.UriSource = new Uri(@"\Resources\image-icon.png", UriKind.Relative);
                    break;
                case ".txt":
                    image.UriSource = new Uri(@"\Resources\txticon.png", UriKind.Relative);
                    break;
                case ".dll":
                    image.UriSource = new Uri(@"\Resources\dllicon.png", UriKind.Relative);
                    break;
                default:
                    image.UriSource = new Uri(@"\Resources\exeicon.png", UriKind.Relative);
                    break;

            }

            image.EndInit();
            Image = image;
        }

        private bool IsDesktop(object window) => _extension == ".dir" && window.ToString().Contains("MainWindow");
    }
}
