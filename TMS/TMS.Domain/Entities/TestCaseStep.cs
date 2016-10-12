using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities
{
    public class TestCaseStep:BaseEntity
    {

        public string StepContent { get; set; }

        public int TestCaseId { get; set; }

        [ForeignKey("TestCaseId")]
        public TestCase TestCase { get; set; } 
    }
}
