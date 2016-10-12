using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Common.Models;
using TMS.Domain.Abstract;
using TMS.Domain.Entities;

namespace TMS.Domain.Concrete
{
    public class EfTestCaseRepository:ITestCaseRepository
    {
        public readonly TmsDbContext context = new TmsDbContext();
        public IEnumerable<TestCaseModel> TestCases()
        {
            return context.TestCases.Include("TestCases").Select(ModelMappers.EntityToModelMappers.EntityTestCaseToModelMapper);
        }

        public void AddTestCase(TestCaseModel testCase)
        {
            var tcase = ModelMappers.ModelToEntityMapper.TestCaseModelToEntityMapper(testCase);
            context.TestCases.Add(tcase);
            context.SaveChanges();

        }

        public TestCaseModel GetTestCase(int testCaseId)
        {
            var testCase = context.TestCases.FirstOrDefault(p => p.ID == testCaseId);
            var model = ModelMappers.EntityToModelMappers.EntityTestCaseToModelMapper(testCase);

            if (testCase == null)
            {
                return model;
            }
 
            return model;
           
        }

        public void EditTestCase(TestCaseModel testCase)
        {
            var tcase = ModelMappers.ModelToEntityMapper.TestCaseModelToEntityMapper(testCase);

            context.Entry(tcase).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteTestCase(int id)
        {

            context.TestCases.Remove(context.TestCases.FirstOrDefault(p => p.ID == id));
        }

        public void Save()
        {


            context.SaveChanges();
        }


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
