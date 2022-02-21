using EasyG.Models.Libraries;

namespace EasyG.ViewModels.Projects
{
    public class CompanyViewModel
    {
        private readonly CompanyData _company;

        public CompanyViewModel(CompanyData company)
        {
            _company = company;
        }

        public string Name => _company.Name;

        public CompanyData GetSourceObject()
        {
            return _company;
        }
    }
}
