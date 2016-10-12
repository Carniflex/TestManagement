using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Abstract;

namespace TMS.Domain.Concrete
{
   public class EFPaymentTypeRepository:IPaymentTypeRepository
    {

       readonly TmsDbContext _context = new TmsDbContext();
        public IEnumerable<Common.Models.ProjectPaymentTypeModel> PaymentTypes()
        {
            return _context.PaymentTypes.Select(ModelMappers.EntityToModelMappers.EntityProjectPaymentTypeToModelMapper);
        }
    }
}
