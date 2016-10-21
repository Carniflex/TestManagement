using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using TMS.Common.Models;
using TMS.Domain.Abstract;
using TMS.Domain.Concrete;
using TMS.WebUI.Models;

namespace TMS.WebUI.Controllers
{
    public class ProjectVersionController : Controller
    {
          private readonly IProjectVersionRepository _projectRepo;
        private readonly TmsDbContext _context;
        public ProjectVersionController() {

            this._projectRepo = new EfProjectVersionRepository();
            this._context= new TmsDbContext();
        }
        public ActionResult ProjectVersions()
        {
            var projects = _projectRepo.ProjectVersions();
            return View(projects);
        }


         public ActionResult CreateProjectVersion() {

         

         


             return View();
        
           
        }


        [HttpPost]
         public JsonResult CreateProjectVersion(ProjectVersionModel project)
        {
            JObject jObject = new JObject();
            try
            {
                if (ModelState.IsValid)
                {
                    
                    _projectRepo.AddProjectVersion(project);
                    _projectRepo.Save();
                    return Json(String.Format("{0}?status=success", Url.Action("ProjectVersions", "ProjectVersion")));
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                  "Try again, and if the problem persists see your system administrator.");
            }
            return Json(new
            {
                
                code="error",
                errors = new[]
                {
                    new ErrorModel
                    {
                        
                        ErrorCode = "error",
                        ErrorMessage = "validation failed",
                        ErrorField =  string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))

                    }
                    
                }

            });
        }

        public ActionResult ProjectDetails(int id)
        {
            return View(_projectRepo.GetProjectVersion(id));
        }


        public ActionResult EditProject(int id=0)
        {
           

            

            

             return View();
        }

        [HttpPost]
        public JsonResult EditProject(ProjectModel project)
        {

            if (ModelState.IsValid)
            {
                _projectRepo.EditProject(project);
                _projectRepo.Save();
                return Json(String.Format("{0}?status=success", Url.Action("Projects", "Project")));
            }
            return Json(new
            {

                code = "error",
                errors = new[]
                {
                    new ErrorModel
                    {
                        
                        ErrorCode = "error",
                        ErrorMessage = "validation failed",
                        ErrorField =  string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))

                    }
                    
                }

            });

        }


        public ActionResult DeleteProject(int id) {

            _projectRepo.DeleteProject(id);
            _projectRepo.Save();
            return RedirectToAction("Projects");
        }
    }
    }
}
