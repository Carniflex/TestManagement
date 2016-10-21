using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common.Models
{
    public class ProjectVersionModel:BaseEntityModel
    {
        public string ProjectVersionName { get; set; }

        public ProjectModel Project { get; set; }

        public int ProjectId { get; set; }

        public IEnumerable<TestPlanModel> TestPlans { get; set; }

    }
}
