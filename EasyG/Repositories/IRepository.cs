using System.Collections.Generic;
using EasyG.Models.Libraries;
using EasyG.Models.Projects;

namespace EasyG.Repositories;

public interface IRepository
{
    IReadOnlyCollection<ProjectData> GetProjects();

    IReadOnlyCollection<CompanyData> GetCompanies();

    void AddNewProject(ProjectData project);
}