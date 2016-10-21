using System;
using TMS.Common.Models;
using TMS.Domain.Entities;

namespace TMS.Domain.ModelMappers
{
    public class EntityToModelMappers
    {


        public static readonly Func<Project, ProjectModel> EntityProjectToModelMapper =
          model => new ProjectModel()
          {
              ID = model.ID,
              ProjectName = model.ProjectName,
              UserId = model.UserId
          };

        public static readonly Func<TestPlan, TestPlanModel> EntityTestPlanToModelMapper =
         model => new TestPlanModel()
         {
             ID = model.ID,
             TestPlanName = model.TestPlanName,
             ProjectVersionId = model.ProjectVersionId
         };

        public static readonly Func<TestSuite, TestSuiteModel> EntityTestSuiteToModelMapper =
         model => new TestSuiteModel()
         {
             ID = model.ID,
             TestSuiteName = model.TestSuiteName,
             TestPlanId = model.TestPlanId

         };

        public static readonly Func<TestCase, TestCaseModel> EntityTestCaseToModelMapper =
         model => new TestCaseModel()
         {
             ID = model.ID,
             TestCaseName = model.TestCaseName,
             RunStatus = model.RunStatus,
             Steps = model.Steps,
             TestSuiteId = model.TestSuiteId
        };



              public static readonly Func<TestCaseRunStatus, TestCaseRunStatusModel> EntityTestCaseRunStatusToModelMapper =
         model => new TestCaseRunStatusModel()
      {
          ID = model.ID,
          Status = model.Status
      };


              public static readonly Func<ProjectVersion, ProjectVersionModel> EntityProjectVersionToModelMapper =
    model => new ProjectVersionModel()
    {
        ID = model.ID,
        ProjectVersionName = model.ProjectVersionName,
        ProjectId = model.ProjectId
       
    };
   
    }
}
