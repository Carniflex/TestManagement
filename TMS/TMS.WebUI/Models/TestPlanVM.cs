using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Common.Models;
using TMS.Domain.Entities;

namespace TMS.WebUI.Models
{
    public class TestPlanVm
    {
        public TestPlanModel testPlanModel { get; set; }
        public List<SelectListItem> relatedToVersion { get; set; }

    }
}