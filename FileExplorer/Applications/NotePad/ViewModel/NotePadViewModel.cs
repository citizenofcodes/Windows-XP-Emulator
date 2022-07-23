using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FileExplorer.Infrastructure.Command;
using FileExplorer.Model;
using FileExplorer.ViewModel;

namespace FileExplorer.Applications.NotePad.ViewModel
{
    internal class NotePadViewModel:BaseVm
    {

        public string Path { get; set; }

        private string _textFieldText;
        public string TextFieldText
        {
            get { return _textFieldText; }
            set { _textFieldText = value; OnPropertyChanged(); }
        }

        private DirectoryModel directoryModel;

        public ICommand SaveFileCommand { get; set; }
        public NotePadViewModel(string path)
        {
            Path = path;

            directoryModel = new DirectoryModel();
            SaveFileCommand = new Command(SaveFile);

            TextFieldText = directoryModel.ReadFileToString(Path);

        }

        private void SaveFile(object o)
        {
           directoryModel.SaveFile(Path,TextFieldText);
        }

        public NotePadViewModel()
        {
            
        }



    }
}
