using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Common.Models;

namespace TMS.WebUI.Models
{
    public class PaymentTypeVm
    {

        public ProjectModel projectModel { get; set; }

        public List<SelectListItem> select { get; set; }
    }
}