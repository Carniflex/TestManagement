using System;
using System.Collections.Generic;

namespace TMS.Common.Models
{
   public class TestSuiteModel:BaseEntityModel
    {

       public TestSuiteModel() {

           this.TestCases = new List<TestCaseModel>();
       }
       public string TestSuiteName { get; set; }

    
        public TestPlanModel TestPlan { get; set; }

        public int TestPlanId { get; set; }

       public virtual IEnumerable<TestCaseModel> TestCases { get; set; }
    }
}
