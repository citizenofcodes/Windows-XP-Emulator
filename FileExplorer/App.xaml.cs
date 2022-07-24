using System;
using System.Windows;
using FileExplorer.Applications.Explorer.ViewModel;
using FileExplorer.Applications.NotePad.ViewModel;
using FileExplorer.Applications.PhotoViewer.ViewModel;
using FileExplorer.Model;
using FileExplorer.View;
using FileExplorer.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FileExplorer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }
        
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<IDirectoryModel, DirectoryService>();
                    services.AddTransient<NotePadViewModel>();
                    services.AddTransient<PhotoViewerViewModel>();
                    services.AddTransient<ExplorerViewModel>();
                    services.AddTransient<MainWindowViewModel>();

                }) 
                .Build();
        }


        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);

        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StartAsync();
            base.OnExit(e);
        }
    }

  
}
