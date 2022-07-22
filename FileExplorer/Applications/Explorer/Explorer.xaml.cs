using FileExplorer.Applications.ApplicationsViewModels;
using System.Windows;

namespace FileExplorer
{
    /// <summary>
    /// Логика взаимодействия для Explorer.xaml
    /// </summary>
    public partial class Explorer : Window
    {
        internal ExplorerViewModel viewModel;
        public Explorer(FileView file)
        {
            InitializeComponent();
            viewModel = new ExplorerViewModel(file);
            DataContext = viewModel;
        }


    }
}
