using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Models;

namespace TMS.Domain.Abstract
{
  public interface ITestCaseStepRepository
    {
      IEnumerable<TestCaseStepModel> TestCaseSteps();
        void AddTestCaseStep(TestCaseStepModel testCaseStep);
        TestCaseStepModel GetTestCaseStep(int testCaseStepId);
        void EditTestCaseStep(TestCaseStepModel testCaseStep);
        void DeleteTestCaseStep(int id);
        void Save();
    }
}
