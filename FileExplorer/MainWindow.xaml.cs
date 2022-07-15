using FileExplorer.Applications;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

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

            if (file.Extension == ".dir")
            {
                Explorer explorer = new Explorer(file);
                explorer.Show();
                file.OpenFileInExplorer(explorer);

            }

            else
            {
                file.OpenFile();
            }
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

        private void StartUp_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            StartUp.Visibility = StartUp.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ExitBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NotePadBtn_OnClick(object sender, RoutedEventArgs e)
        {
            NotePad notePad = new NotePad();
            notePad.Show();
        }
    }
}
