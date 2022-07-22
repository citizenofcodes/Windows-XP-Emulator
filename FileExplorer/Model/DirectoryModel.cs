using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileExplorer.View;

namespace FileExplorer.Model
{
    internal static class DirectoryModel
    {
        public static ObservableCollection<FileView> ShowDirectories(string path)
        {
            ObservableCollection<FileView> directorieslist = new ObservableCollection<FileView>();
            var directories = Directory.EnumerateDirectories(path);
            var files = Directory.EnumerateFiles(path);


            foreach (var directory in directories)
            {
                FileInfo fileinfo = new FileInfo(directory);
                var fileobject = new DirectoryType(fileinfo);
                directorieslist.Add(fileobject);

            }

            foreach (var file in files)
            {
                FileInfo fileinfo = new FileInfo(file);
                var fileobject = new FileType(fileinfo);
                directorieslist.Add(fileobject);
            }

            return directorieslist;
        }
    }
}
