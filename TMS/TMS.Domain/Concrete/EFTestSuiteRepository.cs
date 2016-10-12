using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Common.Models;
using TMS.Domain.Abstract;
using TMS.Domain.Entities;

namespace TMS.Domain.Concrete
{
    public class EFTestSuiteRepository:ITestSuiteRepository
    {
        readonly TmsDbContext _context = new TmsDbContext();
        public IEnumerable<TestSuiteModel> TestSuites()
        {
            var testSuites = _context.TestSuites.ToList().Select(x =>
            {

                var model = ModelMappers.EntityToModelMappers.EntityTestSuiteToModelMapper(x);
                model.TestCases = x.TestCases.Select(p => new TestCaseModel()
           {
               ID = p.ID,
               TestCaseName = p.TestCaseName,
               Author = p.Author,
               TestSuiteId = p.TestSuiteId,
               RunStatus = p.RunStatus,
               SrsLink = p.SrsLink

           });

                return model;
            });
           return testSuites;
        }

        public void AddTestSuite(TestSuiteModel testSuite)
        {
            var suite = ModelMappers.ModelToEntityMapper.TestSuiteModelToEntityMapper(testSuite);
            _context.TestSuites.Add(suite);        
        }
       public  TestSuiteModel GetTestSuite(int TestSuiteId) {

           var suite = _context.TestSuites.Include("TestCases").FirstOrDefault(p => p.ID == TestSuiteId);

           var model = ModelMappers.EntityToModelMappers.EntityTestSuiteToModelMapper(suite);
           if (suite == null)
           {
               return model;
           }
            model.TestCases = suite.TestCases.Select(p => new TestCaseModel()
           {
                 ID = p.ID,
                TestCaseName = p.TestCaseName,
                Author = p.Author,
                TestSuiteId = p.TestSuiteId,
                RunStatus = p.RunStatus,
                SrsLink = p.SrsLink
               
                        });
           return model;
            
        }


       public void EditTestSuite(TestSuiteModel testSuite)
       {

           var suite = ModelMappers.ModelToEntityMapper.TestSuiteModelToEntityMapper(testSuite);
           _context.Entry(suite).State = System.Data.Entity.EntityState.Modified;
       }


       public void DeleteTestSuite(int id)
       {

           _context.TestSuites.Remove(_context.TestSuites.FirstOrDefault(p => p.ID == id));
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
