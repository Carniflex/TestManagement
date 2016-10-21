using System;
using System.Collections.Generic;

namespace TMS.Common.Models
{
    public class TestPlanModel:BaseEntityModel
    {
        public TestPlanModel() {

        }
      
        public string TestPlanName { get; set; }

        public ProjectVersionModel ProjectVersion { get; set; }

        public int ProjectVersionId { get; set; }

    
        public IEnumerable<TestSuiteModel> TestSuites { get; set; }
    }
}
