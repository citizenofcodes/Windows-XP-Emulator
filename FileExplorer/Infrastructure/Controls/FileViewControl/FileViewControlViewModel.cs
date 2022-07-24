using FileExplorer.Applications.Explorer;
using FileExplorer.Applications.Explorer.ViewModel;
using FileExplorer.Applications.NotePad;
using FileExplorer.Applications.NotePad.ViewModel;
using FileExplorer.Applications.PhotoViewer;
using FileExplorer.Applications.PhotoViewer.ViewModel;
using FileExplorer.Infrastructure.Command;
using FileExplorer.ViewModel;
using Microsoft.Extensions.DependencyInjection;
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
                    var npvm = App.AppHost.Services.GetRequiredService<NotePadViewModel>();
                    NotePad notePad = new NotePad();
                    notePad.DataContext = npvm;
                    notePad.Show();
                    npvm.SetupDirectory(Path);
                    break;
                case ".img" or ".png" or ".jgeg":
                    var phvm = App.AppHost.Services.GetRequiredService<PhotoViewerViewModel>();
                    PhotoViewer photoViewer = new PhotoViewer();
                    photoViewer.DataContext = phvm;
                    photoViewer.Show();
                    phvm.SetImagePath(Path);
                    break;
                case ".dir":
                    if (IsDesktop(window))
                    {
                        _explorer = new Explorer();
                        _explorer.Show();
                        var vm = App.AppHost.Services.GetRequiredService<ExplorerViewModel>();
                        _explorer.DataContext = vm;
                        vm.Init(this);
                    }

                    else
                    {
                        _explorer = window as Explorer;
                        if (_explorer != null && _explorer.DataContext is ExplorerViewModel explorer)
                        {
                            explorer.CurrentPath = Path;
                        }
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
