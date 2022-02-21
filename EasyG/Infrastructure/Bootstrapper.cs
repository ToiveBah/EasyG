using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using EasyG.Repositories;
using EasyG.ViewModels;
using EasyG.ViewModels.Projects;
using EasyG.ViewModels.Shared;
using EasyG.Views.Projects;
using MahApps.Metro.Controls.Dialogs;

namespace EasyG.Infrastructure
{
    internal class Bootstrapper
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            //Common infrastructure
            var messenger = new WeakReferenceMessenger();
            builder.RegisterType<FileRepository>().As<IRepository>();
            builder.RegisterInstance(messenger).As<IMessenger>();
            builder.RegisterInstance(DialogCoordinator.Instance).As<IDialogCoordinator>();

            //ViewModels
            builder.RegisterType<NavigationPanelViewModel>().As<INavigationPanelViewModel>();
            builder.RegisterType<ProjectsViewModel>().As<INavigationSource>();
            
            return builder.Build();
        }
    }
}
