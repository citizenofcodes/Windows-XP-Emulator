using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FileExplorer
{
    /// <summary>
    /// Логика взаимодействия для Explorer.xaml
    /// </summary>
    public partial class Explorer : Window
    {
        public Explorer(FileView file)
        {
            InitializeComponent();
            ShowDirectories(file.Path);
            UrlTextBox.Text = file.Path;
        }

        private void ShowDirectories(string path)
        {
            ExplorerGrid.Children.Clear();
            var directories = Directory.EnumerateDirectories(path);
            var files = Directory.EnumerateFiles(path);

            foreach (var directory in directories)
            {
                FileInfo fileinfo = new FileInfo(directory);
                var fileobject = new DirectoryType(fileinfo);
                fileobject.MouseDoubleClick += ButtonBase_OnClick;
                //directoryFile.Click += ButtonBase_OnClick;
                ExplorerGrid.Children.Add(fileobject);

            }

            foreach (var file in files)
            {
                FileInfo fileinfo = new FileInfo(file);
                var fileobject = new FileType(fileinfo);
                fileobject.MouseDoubleClick += ButtonBase_OnClick;
                ExplorerGrid.Children.Add(fileobject);
            }
        }


        private void ButtonBase_OnClick(object sender, MouseButtonEventArgs e)
        {
            var file = (FileView)sender;
            ShowDirectories(file.Path);
        }

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ShowDirectories(UrlTextBox.Text);
            }
        }
    }
}
