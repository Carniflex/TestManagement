using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities
{
    public class TestPlan:BaseEntity
    {

        [Required]
        public string TestPlanName { get; set; }

        [ForeignKey("ProjectVersionId")]
        public virtual ProjectVersion ProjectVersion { get; set; }

        public int ProjectVersionId { get; set; }

        public virtual ICollection<TestSuite> TestSuites { get; set; }
    }
}
