using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities
{
    public class TestCase:BaseEntity
    {


        public TestCase() {

        
                   }

         [Required]
        public string TestCaseName { get; set; }

        public string RunStatus { get; set; }

        [DataType(DataType.MultilineText)]
        public string Steps { get; set; }
        public int TestSuiteId { get; set; }

        [ForeignKey("TestSuiteId")]
        public TestSuite TestSuite { get; set; }

        
    }
}
