using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Models;

namespace TMS.Domain.Abstract
{
    public interface IProjectVersionRepository
    {

        IEnumerable<ProjectVersionModel> ProjectVersions();
        void AddProjectVersion(ProjectVersionModel project);
        ProjectVersionModel GetProjectVersion(int projectId);
        void EditProjectVersion(ProjectVersionModel project);
        void DeleteProjectVersion(int id);
        void Save();
    }
}
