using System;
using System.Globalization;
using System.IO;
using System.Windows;

namespace FileExplorer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowDirectories(@"C:\");
            Clock.Text = DateTime.Now.ToString();
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var file = sender as FileView;
            Explorer explorer = new Explorer(file);
           explorer.Show();

        }
        private void ShowDirectories(string path)
        {
            DesktopGrid.Children.Clear();
            var directories = Directory.EnumerateDirectories(path);
            var files = Directory.EnumerateFiles(path);

            foreach (var directory in directories)
            {
                FileInfo fileinfo = new FileInfo(directory);
                var fileobject = new DirectoryType(fileinfo);
                fileobject.MouseDoubleClick += ButtonBase_OnClick;
                //directoryFile.Click += ButtonBase_OnClick;
                DesktopGrid.Children.Add(fileobject);

            }

            foreach (var file in files)
            {
                FileInfo fileinfo = new FileInfo(file);
                var fileobject = new FileType(fileinfo);
                fileobject.MouseDoubleClick += ButtonBase_OnClick;
                DesktopGrid.Children.Add(fileobject);
            }
        }
    }
}
