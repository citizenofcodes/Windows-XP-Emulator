﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FileExplorer.Infrastructure.Command;
using FileExplorer.Model;
using FileExplorer.Services;
using FileExplorer.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace FileExplorer.Applications.NotePad.ViewModel
{
    internal class NotePadViewModel:BaseVm
    {
        private readonly IDirectoryModel _accessdata;

        public string Path { get; set; }

        private string _textFieldText;
        public string TextFieldText
        {
            get { return _textFieldText; }
            set { _textFieldText = value; OnPropertyChanged(); }
        }

        //private DirectoryModel directoryModel;

        public ICommand SaveFileCommand { get; set; }
        public NotePadViewModel(IDirectoryModel accessdata)
        {
            _accessdata = accessdata;
            //directoryModel = new DirectoryModel();
            SaveFileCommand = new Command(SaveFile);
            
        }

        public void SetupDirectory(string path)
        {
            if (path != null)
            {
                Path = path;
                TextFieldText = _accessdata.ReadFileToString(Path);
            }
        }

        private void SaveFile(object o)
        {
            _accessdata.SaveFile(Path,TextFieldText);
        }

        public void OnClosing(object sender, CancelEventArgs args) => App.AppHost.Services.GetRequiredService<ITaskBarService>().DeleteTaskItem((Window)sender);


    }
}
