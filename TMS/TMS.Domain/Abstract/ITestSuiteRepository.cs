using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Models;
using TMS.Domain.Entities;

namespace TMS.Domain.Abstract
{
    public interface ITestSuiteRepository
    {
        IEnumerable<TestSuiteModel> TestSuites();
        void AddTestSuite(TestSuiteModel testSuite);
        TestSuiteModel GetTestSuite(int testSuiteId);
        void EditTestSuite(TestSuiteModel testSuite);
        void DeleteTestSuite(int id);
        void Save();
    }



}
