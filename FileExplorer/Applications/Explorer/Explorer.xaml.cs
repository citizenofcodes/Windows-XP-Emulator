using System.ComponentModel;
using System.Security.AccessControl;
using System.Windows;
using FileExplorer.Applications.Explorer.ViewModel;
using FileExplorer.Services;
using FileExplorer.View;
using Microsoft.Extensions.DependencyInjection;

namespace FileExplorer.Applications.Explorer
{
    /// <summary>
    /// Логика взаимодействия для Explorer.xaml
    /// </summary>
    public partial class Explorer : Window
    {
       
        internal Explorer()
        {
            InitializeComponent();
            
        }

    }
}
