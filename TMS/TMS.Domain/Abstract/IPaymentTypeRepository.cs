using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Models;

namespace TMS.Domain.Abstract
{
   public interface IPaymentTypeRepository
    {

       IEnumerable<ProjectPaymentTypeModel> PaymentTypes();
    }
}
