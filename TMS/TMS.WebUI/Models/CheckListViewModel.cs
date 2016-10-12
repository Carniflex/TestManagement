using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Common.Models;

namespace TMS.WebUI.Models
{
    public class CheckListViewModel
    {
        public ProjectModel ProjectModel { get; set; }

        public TestPlanModel TestPlanModel { get; set; }

        public List<SelectListItem> SelectTestPlan { get; set; }
        public List<SelectListItem> SelectProject { get; set; }
    }
}