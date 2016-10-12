using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Models;
using TMS.Domain.Entities;

namespace TMS.Domain.Abstract
{
    public interface IProjectRepository
    {
        IEnumerable<ProjectModel> Projects();
        void AddProject(ProjectModel project);
        ProjectModel GetProject(int projectId);
        void EditProject(ProjectModel project);
        void DeleteProject(int id);
        void Save();
    }
}
