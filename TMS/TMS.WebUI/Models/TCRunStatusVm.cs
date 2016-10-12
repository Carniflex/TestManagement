using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Common.Models;

namespace TMS.WebUI.Models
{
    public class TCRunStatusVm
    {
        public TestCaseModel TestCaseModel { get; set; }

        public TestCaseStepModel TestCaseStepModel { get; set; }

        public List<SelectListItem> select { get; set; }
    }
}