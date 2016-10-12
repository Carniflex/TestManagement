
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Domain.Abstract;
using TMS.Domain.Concrete;
using TMS.Domain.Entities;

namespace TMS.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {

           
            kernel.Bind<IProjectRepository>().To<EfProjectRepository>();
            kernel.Bind<ITestPlanRepository>().To<EfTestPlanRepository>();
            kernel.Bind<ITestSuiteRepository>().To<EFTestSuiteRepository>();
            kernel.Bind<ITestCaseRepository>().To<EfTestCaseRepository>();
 
        }
    }
}