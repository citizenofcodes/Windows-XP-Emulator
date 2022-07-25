using System;
using FileExplorer.Infrastructure.Command;
using FileExplorer.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FileExplorer.Applications;
using FileExplorer.Applications.Explorer;
using FileExplorer.Applications.NotePad;
using FileExplorer.Applications.PhotoViewer;
using FileExplorer.Services;
using FileExplorer.View;
using Microsoft.Extensions.DependencyInjection;

namespace FileExplorer.ViewModel
{
    internal class MainWindowViewModel : BaseVm
    {
        private readonly IDirectoryModel _directoryModel;
        private readonly ITaskBarService _taskBarService;
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

        private ObservableCollection<TaskBarItem> _TaskBarWindows;
        public ObservableCollection<TaskBarItem> TaskBarWindows
        {
            get
            {
                return _TaskBarWindows;
            }

            set
            {
                _TaskBarWindows = value; OnPropertyChanged();
            }
        }

        public string StartUpVisibility { get; set; } = "Collapsed";


        public MainWindowViewModel(IDirectoryModel directoryModel, ITaskBarService taskBarService)
        {
            _directoryModel = directoryModel;
            _taskBarService = taskBarService;
            WindowOnLoad = new Command(OnLoad);
            StartUpButtonClick = new Command(StartUpClick);
            NotePadOpenButton = new Command(OpenNotepad);
            

            TaskBarWindows = taskBarService.GeTaskBarItems();
        }

        

        private void OpenNotepad(object obj)
        {
            NotePad notePad = new NotePad();
            notePad.Show();
            MessageBox.Show(TaskBarWindows.Count.ToString());
        }


        private void StartUpClick(object obj)
        {
           
            StartUpVisibility = StartUpVisibility == "Collapsed" ? "Visible" : "Collapsed";

            OnPropertyChanged(nameof(StartUpVisibility));
        }

        public void OnLoad(object obj)
        {
           var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Clock = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            Directories = _directoryModel.ShowDirectories(desktopPath);
            OnPropertyChanged(nameof(Directories));
        }

        
    }
}
