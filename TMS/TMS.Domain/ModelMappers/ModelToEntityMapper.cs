using System;
using TMS.Common.Models;
using TMS.Domain.Entities;

namespace TMS.Domain.ModelMappers
{
    public class ModelToEntityMapper
    {




        public static readonly Func<ProjectModel, Project> ProjectModelToEntityMapper =
            model => new Project()
            {
                ID = model.ID,
                ProjectName = model.ProjectName,
                Status = model.Status,
                PaymentType = model.PaymentType,
                UserId = model.UserId
            };

        public static readonly Func<TestPlanModel, TestPlan> TestPlanModelToEntityMapper =
            model => new TestPlan()
            {
                ID = model.ID,
                TestPlanName = model.TestPlanName,
                ProjectId = model.ProjectId,
                CreatedDeate = model.CreatedDeate,
                Author = model.Author,
                SrsLink = model.SrsLink,
                Status = model.Status
            };

        public static readonly Func<TestSuiteModel, TestSuite> TestSuiteModelToEntityMapper =
            model => new TestSuite()
            {
                ID = model.ID,
                TestSuiteName = model.TestSuiteName,
                CreatedDate = model.CreatedDate,
                Author = model.Author,
                TestPlanId = model.TestPlanId

            };

        public static readonly Func<TestCaseModel, TestCase> TestCaseModelToEntityMapper =
            model => new TestCase()
            {
                ID = model.ID,
                TestCaseName = model.TestCaseName,
                Author = model.Author,
                RunStatus = model.RunStatus,
                SrsLink = model.SrsLink,
                Steps = model.Steps,
                TestSuiteId = model.TestSuiteId


            };



        public static readonly Func<TestPlanStatusModel, TestPlanStatus> TestPlanStatusModelToEntityMapper =
            model => new TestPlanStatus()
            {
                ID = model.ID,
                Status = model.Status
            };


        public static readonly Func<TestCaseRunStatusModel, TestCaseRunStatus> TestCaseRunStatusModelToEntityMapper =
            model => new TestCaseRunStatus()
            {
                ID = model.ID,
                Status = model.Status
            };


        public static readonly Func<ProjectPaymentTypeModel, ProjectPaymentType> ProjectPaymentTypeModelToEntityMapper =
            model => new ProjectPaymentType()
            {
                ID = model.ID,
                PaymentType = model.PaymentType
            };

  
    }
}

