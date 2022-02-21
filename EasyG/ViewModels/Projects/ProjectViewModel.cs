using System;
using CommunityToolkit.Mvvm.ComponentModel;
using EasyG.Models.Projects;

namespace EasyG.ViewModels.Projects
{
    public class ProjectViewModel : ObservableObject
    {
        private readonly ProjectData _project;

        public ProjectViewModel(ProjectData project)
        {
            _project = project;
        }

        public DateTimeOffset DeliveryDate => _project.DeliveryDate;

        public DateTimeOffset CreatedDate => _project.CreatedDate;

        public DateTimeOffset ModifiedDate => _project.ModifiedDate;

        public string Name => _project.Name;

        public string ShortName => _project.ShortName;

        public string State => _project.State;

        public string Address => _project.Address;

        public string Region => _project.Region;

        public string Company => _project?.Company?.Name ?? string.Empty;

        public string Description => _project.Description;

        public ProjectData GetSourceObject()
        {
            return _project;
        }
    }
}
