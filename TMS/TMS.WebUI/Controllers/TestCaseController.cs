using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TMS.Common.Models;
using TMS.Domain.Abstract;
using TMS.Domain.Concrete;
using TMS.Domain.Entities;
using TMS.WebUI.Models;

namespace TMS.WebUI.Controllers
{
    public class TestCaseController : Controller
    {
        //
        // GET: /TestCase/
        private readonly ITestCaseRepository _testCaseRepository;
        private readonly ITestSuiteRepository _suiteRepository;
        private readonly ITestCaseStatusRepository _caseStatusRepository;
        
   
        public TestCaseController() {

            this._testCaseRepository = new EfTestCaseRepository();
            this._suiteRepository = new EFTestSuiteRepository();
            this._caseStatusRepository = new EfTestCaseStatusRepository();
            
        }
    

        public ActionResult CreateTestCase()
        {
            var statuses = _caseStatusRepository.TestCaseRunStatuses();
            

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var p in statuses)
            {

                items.Add(new SelectListItem { Text = p.Status, Value = p.ID.ToString() });

            }

            return PartialView("~/Views/TestCase/CreateTestCase.cshtml",new TCRunStatusVm
            {
                TestCaseModel = new TestCaseModel(),
                select = items
           
            });

        }

        

        [HttpPost]
        public JsonResult CreateTestCase(TestCaseModel testCase)
        {
            var suite = _suiteRepository.GetTestSuite(testCase.TestSuiteId);
           
            var id = suite.TestPlanId;
           try
            {
                if (ModelState.IsValid)
                {
                    testCase.Author = User.Identity.Name;
                    _testCaseRepository.AddTestCase(testCase);
                 
                        return Json(String.Format("{0}?status=success", Url.Action("TestPlanDetails/" +id, "TestPlan")));
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


     

        


        public ActionResult EditTestCase(int id = 0)
        {
            var projects = _caseStatusRepository.TestCaseRunStatuses();


            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var p in projects)
            {

                items.Add(new SelectListItem { Text = p.Status, Value = p.ID.ToString() });

            }

            return PartialView("~/Views/TestCase/EditTestCase.cshtml", new TCRunStatusVm
            {
                TestCaseModel = _testCaseRepository.GetTestCase(id),
                select = items

            });

            
        }

        [HttpPost]
        public ActionResult EditTestCase(TestCaseModel testCase)
        {
            var suite = _suiteRepository.GetTestSuite(testCase.TestSuiteId);
            var id = suite.TestPlanId;

            if (ModelState.IsValid)
            {
              
                _testCaseRepository.EditTestCase(testCase);
                _testCaseRepository.Save();
                return RedirectToAction("TestPlanDetails/" +id, "TestPlan");
            }
            return View(testCase);
        }


        public ActionResult TestCaseDetails(int id = 0)
        {

            return PartialView("~/Views/TestCase/TestCaseDetails.cshtml", _testCaseRepository.GetTestCase(id));
        }


        public ActionResult DeleteTestCase(int id)
        {
            var tcase =_testCaseRepository.GetTestCase(id);
            var suite = _suiteRepository.GetTestSuite((int)tcase.TestSuiteId);
            Int64 sId = suite.TestPlanId;
            _testCaseRepository.DeleteTestCase(id);
            _testCaseRepository.Save();
            return RedirectToAction("TestPlanDetails/" + sId, "TestPlan");
        }
    }
}
