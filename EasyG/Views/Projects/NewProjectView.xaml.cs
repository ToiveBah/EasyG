using EasyG.Infrastructure;
using EasyG.ViewModels.Projects;
using MahApps.Metro.Controls.Dialogs;

namespace EasyG.Views.Projects
{
    public partial class NewProjectView
    {
        public NewProjectView(NewProjectViewModel newProjectViewModel)
        {
            InitializeComponent();
            DataContext = newProjectViewModel;
            newProjectViewModel.OnDialogClose += OnDialogClose;
        }

        private NewProjectViewModel? ViewModel => DataContext as NewProjectViewModel;

        private void OnDialogClose(object? sender, MessageDialogResult e)
        {
            if (ViewModel != null)
                ViewModel.OnDialogClose -= OnDialogClose;

            Client.MainWindow.HideMetroDialogAsync(this);
        }
    }
}
