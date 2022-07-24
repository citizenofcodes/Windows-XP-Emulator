using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using FileExplorer.View;

namespace FileExplorer.Model
{
    internal interface IDirectoryModel
    {
        string ReadFileToString(string path);
        void SaveFile(string path, string textFieldText);

        ObservableCollection<FileView> ShowDirectories(string path);

    }

    internal  class DirectoryService : IDirectoryModel
    {
        public ObservableCollection<FileView> ShowDirectories(string path)
        {
            var directorieslist = new ObservableCollection<FileView>();
            var directories = Directory.EnumerateDirectories(path);
            var files = Directory.EnumerateFiles(path);
            

            foreach (var directory in directories)
            {
                FileInfo fileinfo = new FileInfo(directory);
                var fileobject = new FileView(fileinfo);
                directorieslist.Add(fileobject);
                

            } 

            foreach (var file in files)
            {
                FileInfo fileinfo = new FileInfo(file);
                var fileobject = new FileView(fileinfo);
                directorieslist.Add(fileobject);
            }

            return directorieslist;
        }

        public string ReadFileToString(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string fileText = sr.ReadToEnd();

            fs.Close();
            sr.Close();

            return fileText;
        }

        public void SaveFile(string path, string textFieldText)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(textFieldText);


            sw.Close();
            fs.Close();

            MessageBox.Show("Saved!");
        }

    }
}
