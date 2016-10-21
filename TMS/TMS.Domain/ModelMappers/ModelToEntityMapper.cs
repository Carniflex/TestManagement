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
                UserId = model.UserId
            };

        public static readonly Func<TestPlanModel, TestPlan> TestPlanModelToEntityMapper =
            model => new TestPlan()
            {
                ID = model.ID,
                TestPlanName = model.TestPlanName,
                ProjectVersionId = model.ProjectVersionId
            };

        public static readonly Func<TestSuiteModel, TestSuite> TestSuiteModelToEntityMapper =
            model => new TestSuite()
            {
                ID = model.ID,
                TestSuiteName = model.TestSuiteName,
                TestPlanId = model.TestPlanId

            };

        public static readonly Func<TestCaseModel, TestCase> TestCaseModelToEntityMapper =
            model => new TestCase()
            {
                ID = model.ID,
                TestCaseName = model.TestCaseName,
                RunStatus = model.RunStatus,
                Steps = model.Steps,
                TestSuiteId = model.TestSuiteId


            };



            public static readonly Func<TestCaseRunStatusModel, TestCaseRunStatus> TestCaseRunStatusModelToEntityMapper =
            model => new TestCaseRunStatus()
            {
                ID = model.ID,
                Status = model.Status
            };

            public static readonly Func<ProjectVersionModel, ProjectVersion> ProjectVersionToModelToEntityMapper =
model => new ProjectVersion()
{
    ID = model.ID,
    ProjectVersionName = model.ProjectVersionName,
    ProjectId = model.ProjectId

};

  
    }
}

