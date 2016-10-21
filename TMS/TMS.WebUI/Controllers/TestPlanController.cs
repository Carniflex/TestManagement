using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Common.Models;
using TMS.Domain.Abstract;
using TMS.Domain.Concrete;
using TMS.Domain.Entities;
using TMS.WebUI.Models;

namespace TMS.WebUI.Controllers
{
    public class TestPlanController : Controller
    {
        //
        // GET: /TestPlan/

          private ITestPlanRepository _planrepository;
          private IProjectRepository _projectrepository;
       

        public TestPlanController() {

            this._planrepository = new EfTestPlanRepository();
            this._projectrepository = new EfProjectRepository();
           
        }
        public ActionResult Index()
        {
            var projects = _planrepository.TestPlans();
            return View(projects);
        }

        public ActionResult TestPlanDetails(int Id){

            return View(_planrepository.GetTestPlan(Id));
        
        }

         public ActionResult CreateTestPlan() {

            var projects = _projectrepository.Projects();
           

             List<SelectListItem> items = new List<SelectListItem>();
             List<SelectListItem> statuses = new List<SelectListItem>();

             foreach (var p in projects) {

                 items.Add(new SelectListItem { Text = p.ProjectName, Value = p.ID.ToString() });
             
             }
             foreach (var s in status)
             {
                 statuses.Add(new SelectListItem{Text = s.Status,Value = s.ID.ToString()});
             }
             return View(new TestPlanVm
             {
                 testPlanModel = new TestPlanModel(),
                 relatedToProject = items,
                 status = statuses
             });
        }

        [HttpPost]
        public JsonResult CreateTestPlan(TestPlanModel testPlan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    _planrepository.AddTestPlan(testPlan);
                    _planrepository.Save();
                    return Json(String.Format("{0}?status=success", Url.Action("Index", "TestPlan")));
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                  "Try again, and if the problem persists see your system administrator.");
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

        public ActionResult EditTestPlan(int id = 0)
        {
            var projects = _projectrepository.Projects();
           

            List<SelectListItem> items = new List<SelectListItem>();
            List<SelectListItem> statuses = new List<SelectListItem>();

            foreach (var p in projects)
            {

                items.Add(new SelectListItem { Text = p.ProjectName, Value = p.ID.ToString() });

            }
        
            return View(new TestPlanVm
            {
                testPlanModel = _planrepository.GetTestPlan(id),
                relatedToProject = items,
                status = statuses
            });

        }

        [HttpPost]
        public JsonResult EditTestPlan(TestPlanModel testPlan)
        {

            if (ModelState.IsValid)
            {
               
                _planrepository.EditTestPlan(testPlan);
                _planrepository.Save();
                return Json(String.Format("{0}?status=success", Url.Action("Index", "TestPlan")));
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

        public ActionResult DeleteProject(int id)
        {

            _planrepository.DeleteTestPlan(id);
            _planrepository.Save();
            return RedirectToAction("Index");
        }
    }
    }

