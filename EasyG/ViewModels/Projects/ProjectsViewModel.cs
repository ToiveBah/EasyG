using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyG.Infrastructure;
using EasyG.Repositories;
using EasyG.Views.Projects;
using MahApps.Metro.Controls.Dialogs;

namespace EasyG.ViewModels.Projects
{
    public class ProjectsViewModel : ObservableObject, INavigationSource
    {
        private IRepository _repository;
        private ProjectViewModel? _project;
        private string? _searchText;
        private ICommand? _createNewProjectCommand;

        public ProjectsViewModel(IRepository repository)
        {
            _repository = repository;
            Initialize();
        }

        private void Initialize()
        {
            Projects = new ObservableCollection<ProjectViewModel>();
            var projectsData = _repository.GetProjects();
            foreach (var projectData in projectsData)
                Projects.Add(new ProjectViewModel(projectData));

            ProjectsView = new CollectionView(Projects);
        }

        public ICommand CreateNewProjectCommand => _createNewProjectCommand ??= new RelayCommand(CreateNewProject);
        
        public ICollectionView? ProjectsView { get; private set; }

        public ObservableCollection<ProjectViewModel>? Projects { get; set; }

        public ProjectViewModel? Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        public string Name => Resources.LocalizationResources.ProjectsView_Title;

        public string? SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        private async void CreateNewProject()
        {
            var newProjectViewModel = new NewProjectViewModel(_repository);
            var dialog = new NewProjectView(newProjectViewModel);
            await Client.MainWindow.ShowMetroDialogAsync(dialog);
            await dialog.WaitUntilUnloadedAsync();

            if (newProjectViewModel.Result == MessageDialogResult.Affirmative)
            {
                var project = newProjectViewModel.Build();
                _repository.AddNewProject(project);
                Projects?.Add(new ProjectViewModel(project));
                ProjectsView?.Refresh();
            }
        }
    }
}
