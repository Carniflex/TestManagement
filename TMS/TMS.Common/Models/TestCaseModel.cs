using System;
using System.Collections.Generic;

namespace TMS.Common.Models
{
    public class TestCaseModel:BaseEntityModel
    {


        public TestCaseModel() {

            this.SrsLink = "none";
        

        }

        public string TestCaseName { get; set; }

        public string Author { get; set; }
  

        public string SrsLink { get; set; }

        public string RunStatus { get; set; }

       
        public string Steps { get; set; }
        public int TestSuiteId { get; set; }

        public TestSuiteModel TestSuite { get; set; }

      
    }
}
