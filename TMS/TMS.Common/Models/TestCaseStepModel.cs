using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common.Models
{
    public class TestCaseStepModel:BaseEntityModel
    {

        public string StepContent { get; set; }

        public TestCaseModel TestCaseModel { get; set; }
        public int TestCaseId { get; set; }

    }
}
