using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities
{
   public class TestSuite:BaseEntity
    {

       public TestSuite() {

        
       }
       public string TestSuiteName { get; set; }

       [ForeignKey("TestPlanId")]
       public TestPlan TestPlan { get; set; }

      public int TestPlanId { get; set; }

       [InverseProperty("TestSuite")]
       public virtual ICollection<TestCase> TestCases { get; set; }
    }
}
