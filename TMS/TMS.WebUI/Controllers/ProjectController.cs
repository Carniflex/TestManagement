using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json.Linq;
using TMS.Common.Models;
using TMS.Domain.Abstract;
using TMS.Domain.Concrete;
using TMS.WebUI.Models;
using WebMatrix.WebData;

namespace TMS.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        private readonly IProjectRepository _projectRepo;
        private readonly TmsDbContext _context;
        public ProjectController() {

            this._projectRepo = new EfProjectRepository();
            this._context= new TmsDbContext();
        }
        public ActionResult Projects()
        {
            var projects = _projectRepo.Projects();
            return View(projects);
        }


         public ActionResult CreateProject() {

         

            return View();
        
           
        }


        [HttpPost]
         public JsonResult CreateProject(ProjectModel project)
        {
            JObject jObject = new JObject();
            try
            {
                if (ModelState.IsValid)
                {
                    project.UserId =_context.UserProfiles.Where(n=>n.UserName==User.Identity.Name).Select(x=>x.UserId).FirstOrDefault();
                    _projectRepo.AddProject(project);
                    _projectRepo.Save();
                    return Json(String.Format("{0}?status=success", Url.Action("Projects", "Project")));
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
            return View(_projectRepo.GetProject(id));
        }


        public ActionResult EditProject(int id=0)
        {
           

             List<SelectListItem> items = new List<SelectListItem>();

            

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

