using System.Windows;
using FileExplorer.Applications.Explorer.ViewModel;
using FileExplorer.View;

namespace FileExplorer.Applications.Explorer
{
    /// <summary>
    /// Логика взаимодействия для Explorer.xaml
    /// </summary>
    public partial class Explorer : Window
    {
        internal ExplorerViewModel viewModel;
        internal Explorer(FileViewControlViewModel file)
        {
            InitializeComponent();
            viewModel = new ExplorerViewModel(file);
            DataContext = viewModel;
        }


    }
}
