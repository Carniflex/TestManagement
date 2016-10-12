using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Abstract;

namespace TMS.Domain.Concrete
{
    public class EfTestCaseStatusRepository : ITestCaseStatusRepository
    {
        readonly TmsDbContext _context = new TmsDbContext();
        public IEnumerable<Common.Models.TestCaseRunStatusModel> TestCaseRunStatuses()
        {
            return _context.RunStatuses.Select(ModelMappers.EntityToModelMappers.EntityTestCaseRunStatusToModelMapper);
        }
    }
}
