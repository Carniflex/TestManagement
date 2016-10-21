using System;
using System.Collections.Generic;

namespace TMS.Common.Models
{
    public class TestCaseModel:BaseEntityModel
    {


        public TestCaseModel() {

          
        
        }

        public string TestCaseName { get; set; }

        public string RunStatus { get; set; }

        public string Steps { get; set; }
        public int TestSuiteId { get; set; }

        public TestSuiteModel TestSuite { get; set; }

      
    }
}
