using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Common.Models;
using TMS.Domain.Abstract;
using TMS.Domain.Concrete;

namespace TMS.WebUI.Controllers
{
    public class CheckListController : Controller
    {
        //
        // GET: /CheckList/
        private readonly IProjectRepository _projectRepo;
        private readonly ITestPlanRepository _testPlanRepository;
        private readonly ITestSuiteRepository _testSuiteRepository;
        private readonly TmsDbContext _context;
        public CheckListController()
        {

            this._projectRepo = new EfProjectRepository();
            this._testPlanRepository = new EfTestPlanRepository();
            this._testSuiteRepository = new EFTestSuiteRepository();
            

        }
        public ActionResult CheckListIndex()
        {
            return View();
        }


        public ActionResult getProjects()
        {

            var projects = _projectRepo.Projects();
            return Json(projects, JsonRequestBehavior.AllowGet);
        }


        public ActionResult getTestPlans(int projectId)
        {

            var testPlans = _testPlanRepository.TestPlans().Where(p => p.ProjectVersionId == projectId);
            return Json(testPlans, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getCheckList(int testPlanId)
        {

            var testSuites = _testSuiteRepository.TestSuites();

            return Json(testSuites, JsonRequestBehavior.AllowGet);

        }
    }
}
