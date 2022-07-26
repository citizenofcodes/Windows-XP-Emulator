using System.Windows;
using FileExplorer.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace FileExplorer.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.AppHost.Services.GetRequiredService<MainWindowViewModel>();
        }
    
       //gg

       
        
    }
}
