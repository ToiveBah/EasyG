using System.Windows;
using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using EasyG.Infrastructure;
using EasyG.Repositories;
using EasyG.ViewModels;

namespace EasyG
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = Bootstrapper.Build();
            var repository = container.Resolve<IRepository>();
            var messenger = container.Resolve<IMessenger>();
            var viewModel = new MainWindowViewModel(container, repository, messenger);
            var window = new MainWindow(viewModel);
            Client.MainWindow = window;

            window.Show();
        }
    }
}
