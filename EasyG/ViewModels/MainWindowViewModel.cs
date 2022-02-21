using System;
using System.Collections.Generic;
using Autofac;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using EasyG.Messages;
using EasyG.Repositories;
using EasyG.ViewModels.Shared;

namespace EasyG.ViewModels
{
    public class MainWindowViewModel : ObservableObject, IDisposable
    {
        private readonly IContainer _container;
        private readonly IRepository _repository;
        private readonly IMessenger _messenger;
        private INavigationPanelViewModel? _navigationPanelViewModel;
        private INavigationSource? _currentViewModel;

        public MainWindowViewModel(IContainer container, IRepository repository, IMessenger messenger)
        {
            _repository = repository;
            _container = container;
            _messenger = messenger;

            Initialize();
        }

        public string Title => Resources.LocalizationResources.MainWindow_Title;

        private void Initialize()
        {
            _navigationPanelViewModel = _container.Resolve<INavigationPanelViewModel>();
            var views = _container.Resolve<IEnumerable<INavigationSource>>();
            _navigationPanelViewModel.RegisterViews(views);
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            _messenger.Register<CurrentActiveViewChangesMessage>(this, OnNavigationSourceChanged);
        }

        private void OnNavigationSourceChanged(object recipient, CurrentActiveViewChangesMessage message)
        {
            CurrentViewModel = message.NavigationSource;
        }

        private void UnregisterMessages()
        {
            _messenger.Unregister<CurrentActiveViewChangesMessage>(this);
        }

        public INavigationPanelViewModel? NavigationPanelViewModel => _navigationPanelViewModel;

        public INavigationSource? CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public void Dispose()
        {
            UnregisterMessages();
            _container.Dispose();
        }
    }
}
