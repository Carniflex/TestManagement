using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Models;
using TMS.Domain.Entities;

namespace TMS.Domain.Abstract
{
    public interface ITestCaseRepository
    {
        IEnumerable<TestCaseModel> TestCases();
        void AddTestCase(TestCaseModel testCase);
        TestCaseModel GetTestCase(int testCaseId);
        void EditTestCase(TestCaseModel testCase);

        void DeleteTestCase(int id);
        void Save();
    }
}
