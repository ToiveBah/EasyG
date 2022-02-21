using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using EasyG.Messages;

namespace EasyG.ViewModels.Shared
{
    public class NavigationPanelViewModel : ObservableObject, INavigationPanelViewModel
    {
        private bool _isExpandedMode;
        private INavigationSource _currentSource;
        private IMessenger _messenger;

        public NavigationPanelViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            NavigationObjects = new ObservableCollection<INavigationSource>();
            NavigationObjectsCollectionView = new CollectionView(NavigationObjects);
        }

        public void RegisterView(INavigationSource navigationSource)
        {
            NavigationObjects.Add(navigationSource);
        }

        public void RegisterViews(IEnumerable<INavigationSource> navigationSources)
        {
            foreach (var navigationSource in navigationSources)
                NavigationObjects.Add(navigationSource);
        }

        public ICollectionView NavigationObjectsCollectionView { get; }

        public ObservableCollection<INavigationSource> NavigationObjects { get; set; }

        public INavigationSource CurrentSource
        {
            get => _currentSource;
            set
            {
                SetProperty(ref _currentSource, value);
                _messenger.Send(new CurrentActiveViewChangesMessage(this, value));
            }
        }

        public bool IsExpandedMode
        {
            get => _isExpandedMode;
            set => SetProperty(ref _isExpandedMode, value);
        }
    }
}
