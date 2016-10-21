using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities
{
    public class ProjectVersion:BaseEntity
    {
        public string ProjectVersionName { get; set; }

        public Project Project { get; set; }

        public int ProjectId { get; set; }

        public ICollection<TestPlan> TestPlans { get; set; }

    }
}
