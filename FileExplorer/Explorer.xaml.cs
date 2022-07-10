using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace FileExplorer
{
    /// <summary>
    /// Логика взаимодействия для Explorer.xaml
    /// </summary>
    public partial class Explorer : Window
    {
        private string _currentPath;
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

            _currentPath = file.Path;
            UrlTextBox.Text = _currentPath;
            ShowDirectories(_currentPath);
            
        }

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ShowDirectories(UrlTextBox.Text);
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(_currentPath);
            if (dirinfo.Parent != null)
            {
                _currentPath = dirinfo.Parent.FullName;
            }

            ShowDirectories(_currentPath);
            UrlTextBox.Text = _currentPath;


        }
    }
}
