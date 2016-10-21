using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TMS.Common.Models;
using TMS.Domain.Abstract;
using TMS.Domain.Entities;

namespace TMS.Domain.Concrete
{
    public class EfProjectRepository : IProjectRepository
    {
        readonly TmsDbContext _context = new TmsDbContext();
        public IEnumerable<ProjectModel> Projects()
        {
            var projects = _context.Projects.Select(ModelMappers.EntityToModelMappers.EntityProjectToModelMapper);
            return projects;
        }


        public void AddProject(ProjectModel projectModel)
        {
            var project = ModelMappers.ModelToEntityMapper.ProjectModelToEntityMapper(projectModel);
            _context.Projects.Add(project);

        }

        public ProjectModel GetProject(int projectId)
        {
            var project =  _context.Projects.FirstOrDefault(p => p.ID == projectId);

            var model = ModelMappers.EntityToModelMappers.EntityProjectToModelMapper(project);
            if (project == null)
            {
                return model;
            }
            model.ProjectVersions = project.ProjectVersions.Select(p => new ProjectVersionModel()
            {
                ID = p.ID,
                ProjectId = p.ProjectId,
                ProjectVersionName = p.ProjectVersionName

            });
            return model;
        }

        public void EditProject(ProjectModel project)
        {
            var proj = ModelMappers.ModelToEntityMapper.ProjectModelToEntityMapper(project);
            _context.Entry(proj).State = EntityState.Modified;
          
         
        }

        public void DeleteProject(int id) {

            _context.Projects.Remove(_context.Projects.FirstOrDefault(p => p.ID == id));
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
