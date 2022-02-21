using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyG.Models.Projects;
using EasyG.Repositories;
using MahApps.Metro.Controls.Dialogs;

namespace EasyG.ViewModels.Projects
{
    public class NewProjectViewModel : ObservableObject
    {
        private readonly IRepository _repository;
        private DateTimeOffset _deliveryDate;
        private string? _name;
        private string? _shortName;
        private string? _state;
        private string? _address;
        private string? _region;
        private CompanyViewModel? _company;
        private string? _description;
        private ICommand? _closeDialogCommand;

        public event EventHandler<MessageDialogResult>? OnDialogClose;

        public NewProjectViewModel(IRepository repository)
        {
            _repository = repository;
            Initialize();
        }

        private void Initialize()
        {
            Companies = new ObservableCollection<CompanyViewModel>();
            var companies = _repository.GetCompanies();
            foreach (var company in companies)
            {
                Companies.Add(new CompanyViewModel(company));
            }
        }

        public DateTimeOffset DeliveryDate
        {
            get => _deliveryDate;
            set => SetProperty(ref _deliveryDate, value);
        }

        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string? ShortName
        {
            get => _shortName;
            set => SetProperty(ref _shortName, value);
        }

        public string? State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        public string? Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        public string? Region
        {
            get => _region;
            set => 
                SetProperty(ref _region, value);
        }

        public ObservableCollection<CompanyViewModel>? Companies { get; private set; }

        public CompanyViewModel? Company
        {
            get => _company;
            set => SetProperty(ref _company, value);
        }

        public string? Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public ICommand CloseDialogCommand => _closeDialogCommand ??= new RelayCommand<MessageDialogResult>(CloseDialog, result => true);

        public MessageDialogResult Result { get; private set; }

        private void CloseDialog(MessageDialogResult messageDialogResult)
        {
            OnDialogClose?.Invoke(this, messageDialogResult);
            Result = messageDialogResult;
        }

        public ProjectData Build()
        {
            return new ProjectData
            {
                Name = Name,
                ShortName = ShortName,
                DeliveryDate = DeliveryDate,
                CreatedDate = DateTimeOffset.Now,
                ModifiedDate = DateTimeOffset.Now,
                State = State,
                Address = Address,
                Company = Company?.GetSourceObject(),
                Description = Description,
                Region = Region
            };
        }
    }
}
