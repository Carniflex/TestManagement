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

namespace TMS.WebUI.Controllers
{
    public class TestSuiteController : Controller
    {
        //
        // GET: /TestSuite/
        
          private ITestSuiteRepository _suiteRepository;

          public TestSuiteController()
          {

            this._suiteRepository = new EFTestSuiteRepository();
        }
     
        [HttpGet]
        public ActionResult CreateTestSuite()
        {

            return PartialView("~/Views/TestSuite/CreateTestSuite.cshtml");
        }

        [HttpPost]
        public ActionResult CreateTestSuite(TestSuiteModel testSuite)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    testSuite.Author = User.Identity.Name;
                    _suiteRepository.AddTestSuite(testSuite);
                    _suiteRepository.Save();
                    return RedirectToAction("TestPlanDetails/"+testSuite.TestPlanId,"TestPlan");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                  "Try again, and if the problem persists see your system administrator.");
            }
            return View(testSuite);
        }

        public ActionResult EditTestSuite(int id = 0)
        {
            TestSuiteModel testSuite = _suiteRepository.GetTestSuite(id);

            return PartialView("~/Views/TestSuite/EditTestSuite.cshtml",testSuite);
        }

        [HttpPost]
        public ActionResult EditTestSuite(TestSuiteModel testSuite)
        {

            if (ModelState.IsValid)
            {
                testSuite.Author = User.Identity.Name;
                _suiteRepository.EditTestSuite(testSuite);
                _suiteRepository.Save();
                return RedirectToAction("TestPlanDetails/" + testSuite.TestPlanId, "TestPlan");
            }
            return View(testSuite);
        }


        public ActionResult TestSuiteDetails(int id=0) {

            var suite = _suiteRepository.GetTestSuite(id);
            return PartialView("~/Views/TestSuite/TestSuiteDetails.cshtml", suite);
        }


        public ActionResult DeleteTestSuite(int id)
        {
            var suite = _suiteRepository.GetTestSuite(id);
            Int64 sId = suite.TestPlanId;
            _suiteRepository.DeleteTestSuite(id);
            _suiteRepository.Save();
            return RedirectToAction("TestPlanDetails/" + sId, "TestPlan");
        }
    }



}
