using System;
using System.Collections.Generic;

namespace TMS.Common.Models
{
    public class TestPlanModel:BaseEntityModel
    {


        public TestPlanModel() {

            this.CreatedDeate = DateTime.Now;
            this.SrsLink = "none";
        }
      
        public string TestPlanName { get; set; }

        public ProjectModel Project { get; set; }

        public int ProjectId { get; set; }

        public string Author { get; set; }

        public DateTime CreatedDeate { get; set; }

        public string SrsLink { get; set; }

        public string Status { get; set; }
        public IEnumerable<TestSuiteModel> TestSuites { get; set; }
    }
}
