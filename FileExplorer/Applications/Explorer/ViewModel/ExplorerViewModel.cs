﻿using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using FileExplorer.Infrastructure.Command;
using FileExplorer.Model;
using FileExplorer.View;
using FileExplorer.ViewModel;

namespace FileExplorer.Applications.Explorer.ViewModel
{
    internal class ExplorerViewModel : BaseVm
    {
        private readonly IDirectoryModel _directoryModel;

        public ICommand UrlEnterCommand { get; set; }

        public ICommand ClickBackButtonCommand { get; set; }

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

        private string _currentPath;

        public string CurrentPath
        {
            get
            {
                return _currentPath;
            }
            set
            {
                _currentPath = value;
                _urlText = value;
                OnPathChanged();
            }
        }

        public ExplorerViewModel(IDirectoryModel directoryModel)
        {
            _directoryModel = directoryModel;
            ClickBackButtonCommand = new Command(ClickBackButton);
            UrlEnterCommand = new Command(o => { CurrentPath = UrlText; });
         
        }

        private string _urlText;
        public string UrlText
        {
            get
            {
                {
                    return _urlText;
                }

            }
            set { _urlText = value; OnPropertyChanged(); }
        }

        public void Init(FileViewControlViewModel File)
        {
            CurrentPath = File.Path;
            UrlText = CurrentPath;
            OnPropertyChanged(CurrentPath);
            OnPropertyChanged(UrlText);
        }

        public void ClickBackButton(object obj)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(CurrentPath);
            if (dirinfo.Parent != null)
            {
                CurrentPath = dirinfo.Parent.FullName;
            }

        }

        public void OnPathChanged()
        {
            Directories = _directoryModel.ShowDirectories(CurrentPath);
            OnPropertyChanged(nameof(CurrentPath));
            OnPropertyChanged(nameof(UrlText));
        }
    }
}
