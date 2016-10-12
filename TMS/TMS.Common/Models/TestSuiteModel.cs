using System;
using System.Collections.Generic;

namespace TMS.Common.Models
{
   public class TestSuiteModel:BaseEntityModel
    {

       public TestSuiteModel() {

           this.CreatedDate = DateTime.Now;
           this.TestCases = new List<TestCaseModel>();
       }
       public string TestSuiteName { get; set; }

    
       public TestPlanModel TestPlan { get; set; }

       public string Author { get; set; }

       public DateTime CreatedDate { get; set; }
   
       public int TestPlanId { get; set; }

       public virtual IEnumerable<TestCaseModel> TestCases { get; set; }
    }
}
