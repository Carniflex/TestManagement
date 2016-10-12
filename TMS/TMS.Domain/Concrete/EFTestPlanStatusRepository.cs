using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Abstract;

namespace TMS.Domain.Concrete
{
    public class EFTestPlanStatusRepository:ITestPlanStatusRepository
    {
        readonly TmsDbContext _context = new TmsDbContext();
        public IEnumerable<Common.Models.TestPlanStatusModel> TestPlanStatuses()
        {
            return _context.TestPlanStatuses.Select(ModelMappers.EntityToModelMappers.EntityTestPlanStatusToModelMapper);
        }
    }
}
