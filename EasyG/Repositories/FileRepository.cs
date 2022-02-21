using System.Collections.Generic;
using EasyG.Models.Libraries;
using EasyG.Models.Projects;

namespace EasyG.Repositories;

public class FileRepository : IRepository
{
    private List<ProjectData> projects = new List<ProjectData>();

    public IReadOnlyCollection<ProjectData> GetProjects()
    {
        //TODO Return Projects Collection
        return projects;
    }

    public IReadOnlyCollection<CompanyData> GetCompanies()
    {
        //TODO Return Company Collection
        return new List<CompanyData>();
    }

    public void AddNewProject(ProjectData project)
    {
        projects.Add(project);
    }
}