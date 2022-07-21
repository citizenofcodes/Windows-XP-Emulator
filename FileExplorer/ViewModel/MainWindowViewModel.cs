using System;
using FileExplorer.Infrastructure.Command;
using FileExplorer.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using FileExplorer.Applications;

namespace FileExplorer.ViewModel
{
    internal class MainWindowViewModel : BaseVm
    {
        public ICommand WindowOnLoad { get; set; }

        public ICommand StartUpButtonClick { get; set; }

        public ICommand NotePadOpenButton { get; }


        private string _clock;
        public string Clock
        {
            get
            {
                return _clock;
            }

            set
            {
                _clock = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<FileView> _directories;
        public ObservableCollection<FileView> Directories
        {

            get
            {
                return _directories;
            }
            set
            {
                _directories = value; OnPropertyChanged();
            }
        }

        public string StartUpVisibility { get; set; } = "Collapsed";


        public MainWindowViewModel()
        {
            WindowOnLoad = new Command(OnLoad);
            StartUpButtonClick = new Command(StartUpClick);
            NotePadOpenButton = new Command(OpenNotepad);
        }

        private void OpenNotepad(object obj)
        {
            NotePad notePad = new NotePad();
            notePad.Show();
        }


        private void StartUpClick(object obj)
        {
           
            StartUpVisibility = StartUpVisibility == "Collapsed" ? "Visible" : "Collapsed";

            OnPropertyChanged(nameof(StartUpVisibility));
        }

        public void OnLoad(object obj)
        {

            Clock = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            Directories = DirectoryModel.ShowDirectories(@"C:\");
        }

        
    }
}
