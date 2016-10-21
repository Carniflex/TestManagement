using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Models;
using TMS.Domain.Abstract;

namespace TMS.Domain.Concrete
{
    public class EfProjectVersionRepository:IProjectVersionRepository
    {
        readonly TmsDbContext _context = new TmsDbContext();
        public IEnumerable<ProjectVersionModel> ProjectVersions()
        {
            var projectVersions = _context.ProjectVersions.Select(ModelMappers.EntityToModelMappers.EntityProjectVersionToModelMapper);
            return projectVersions;
        }

        public void AddProjectVersion(ProjectVersionModel project)
        {
            var projectVersion = ModelMappers.ModelToEntityMapper.ProjectVersionToModelToEntityMapper(project);
            _context.ProjectVersions.Add(projectVersion);
        }

        public ProjectVersionModel GetProjectVersion(int projectId)
        {
            var projectVersion = _context.ProjectVersions.FirstOrDefault(p => p.ID == projectId);

            var model = ModelMappers.EntityToModelMappers.EntityProjectVersionToModelMapper(projectVersion);

            if (projectVersion == null)
            {
                return model;
            }
            model.TestPlans = projectVersion.TestPlans.Select(p => new TestPlanModel()
            {
                ID = p.ID,
                ProjectVersionId = p.ProjectVersionId,
                TestPlanName = p.TestPlanName

            });
            return model;
        }

        public void EditProjectVersion(ProjectVersionModel project)
        {
            var proj = ModelMappers.ModelToEntityMapper.ProjectVersionToModelToEntityMapper(project);
            _context.Entry(proj).State = EntityState.Modified;
        }

        public void DeleteProjectVersion(int id)
        {
            _context.ProjectVersions.Remove(_context.ProjectVersions.FirstOrDefault(p => p.ID == id));
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
