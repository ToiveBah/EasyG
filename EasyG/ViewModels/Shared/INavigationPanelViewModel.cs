using System.Collections.Generic;
using System.ComponentModel;

namespace EasyG.ViewModels.Shared;

public interface INavigationPanelViewModel
{
    void RegisterView(INavigationSource navigationSource);

    void RegisterViews(IEnumerable<INavigationSource> navigationSources);

    ICollectionView NavigationObjectsCollectionView { get; }

    bool IsExpandedMode { get; set; }
}