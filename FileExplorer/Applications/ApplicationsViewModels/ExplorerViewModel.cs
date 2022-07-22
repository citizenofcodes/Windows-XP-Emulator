﻿using FileExplorer.Infrastructure.Command;
using FileExplorer.Model;
using FileExplorer.ViewModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Policy;
using System.Windows.Input;

namespace FileExplorer.Applications.ApplicationsViewModels
{
    internal class ExplorerViewModel : BaseVm
    {

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

        public ExplorerViewModel(FileView file)
        {
            ClickBackButtonCommand = new Command(ClickBackButton);
            UrlEnterCommand = new Command(UrlEnterPush);
            CurrentPath = file.Path;
            UrlText = CurrentPath;
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

        private void UrlEnterPush(object obj)
        {
            CurrentPath = UrlText;
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
            Directories = DirectoryModel.ShowDirectories(CurrentPath);
            OnPropertyChanged(nameof(CurrentPath));
            OnPropertyChanged(nameof(UrlText));
        }
    }
}