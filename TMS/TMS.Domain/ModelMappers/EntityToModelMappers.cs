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
              Status = model.Status,
              PaymentType = model.PaymentType,
              UserId = model.UserId
          };

        public static readonly Func<TestPlan, TestPlanModel> EntityTestPlanToModelMapper =
         model => new TestPlanModel()
         {
             ID = model.ID,
             TestPlanName = model.TestPlanName,
             ProjectId = model.ProjectId,
             CreatedDeate = model.CreatedDeate,
             Author = model.Author,
             SrsLink = model.SrsLink,
             Status = model.Status
         };

        public static readonly Func<TestSuite, TestSuiteModel> EntityTestSuiteToModelMapper =
         model => new TestSuiteModel()
         {
             ID = model.ID,
             TestSuiteName = model.TestSuiteName,
             CreatedDate = model.CreatedDate,
             Author = model.Author,
             TestPlanId = model.TestPlanId

         };

        public static readonly Func<TestCase, TestCaseModel> EntityTestCaseToModelMapper =
         model => new TestCaseModel()
         {
             ID = model.ID,
             TestCaseName = model.TestCaseName,
             Author = model.Author,
             RunStatus = model.RunStatus,
             SrsLink = model.SrsLink,
             Steps = model.Steps,
             TestSuiteId = model.TestSuiteId


         };



        public static readonly Func<TestPlanStatus, TestPlanStatusModel> EntityTestPlanStatusToModelMapper =
        model => new TestPlanStatusModel()
        {
            ID = model.ID,
            Status = model.Status
        };


        public static readonly Func<TestCaseRunStatus, TestCaseRunStatusModel> EntityTestCaseRunStatusToModelMapper =
         model => new TestCaseRunStatusModel()
      {
          ID = model.ID,
          Status = model.Status
      };


        public static readonly Func<ProjectPaymentType, ProjectPaymentTypeModel> EntityProjectPaymentTypeToModelMapper =
        model => new ProjectPaymentTypeModel()
    {
        ID = model.ID,
        PaymentType = model.PaymentType
    };

        public static readonly Func<TestCaseStep, TestCaseStepModel> EntityTestCaseStepToModelMapper =
      model => new TestCaseStepModel()
      {
          ID = model.ID,
          StepContent = model.StepContent
      };

    }
}
