using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Common.Models;
using TMS.Domain.Abstract;
using TMS.Domain.Entities;

namespace TMS.Domain.Concrete
{
    public class EfTestPlanRepository:ITestPlanRepository
    {
        readonly TmsDbContext _context = new TmsDbContext();
        public IEnumerable<TestPlanModel> TestPlans()
        {
            var testPlans = _context.TestPlans.Select(ModelMappers.EntityToModelMappers.EntityTestPlanToModelMapper);
            return testPlans;
        }


          public void AddTestPlan(TestPlanModel testPlanModel)
        {
            var testPlan = ModelMappers.ModelToEntityMapper.TestPlanModelToEntityMapper(testPlanModel);
            _context.TestPlans.Add(testPlan);

        }


          public  TestPlanModel GetTestPlan(int testPlanId)
          {
              var testPlan = _context.TestPlans.FirstOrDefault(p => p.ID == testPlanId);
              var testPlanModel = ModelMappers.EntityToModelMappers.EntityTestPlanToModelMapper(testPlan);
                if (testPlan == null)
                {
                    return testPlanModel;
                }
                testPlanModel.TestSuites = testPlan.TestSuites.Select(p => new TestSuiteModel()
                {
                    ID = p.ID,
                    TestSuiteName = p.TestSuiteName,
                    Author = p.Author,
                    TestPlanId = p.TestPlanId,
                    CreatedDate = p.CreatedDate,
                    TestCases = p.TestCases.Select(c=>new TestCaseModel()
                    {

                        ID = c.ID,
                        TestCaseName = c.TestCaseName,
                        Author = c.Author,
                        TestSuiteId = c.TestSuiteId,                       
                        RunStatus = c.RunStatus,
                        SrsLink = c.SrsLink
                    })
                                          
                });

              return testPlanModel;
          }

          public void EditTestPlan(TestPlanModel testPlanModel)
          {
              var testPlan = ModelMappers.ModelToEntityMapper.TestPlanModelToEntityMapper(testPlanModel);
             _context.Entry(testPlan).State = System.Data.Entity.EntityState.Modified;

          }

          public void DeleteTestPlan(int id)
          {

              _context.TestPlans.Remove(_context.TestPlans.FirstOrDefault(p => p.ID == id));
          }


        public void Save()
        {


            _context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    }

