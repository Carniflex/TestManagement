using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Models;
using TMS.Domain.Entities;

namespace TMS.Domain.Abstract
{
   public interface ITestPlanRepository
   {
         IEnumerable<TestPlanModel> TestPlans();
        void AddTestPlan(TestPlanModel testPlanModel);
        TestPlanModel GetTestPlan(int testPlanId);
        void EditTestPlan(TestPlanModel testPlanModel);

        void DeleteTestPlan(int id);
        void Save();
    }
}
