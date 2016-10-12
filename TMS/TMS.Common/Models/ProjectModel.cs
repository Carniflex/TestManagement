using System;
using System.Collections.Generic;


namespace TMS.Common.Models
{
   public class ProjectModel:BaseEntityModel
    {

      public string ProjectName { get; set; }

      public string PaymentType { get; set; }

      public string Status { get; set; }

      public UserModel User { get; set; }

      public int UserId { get; set; }

      public IEnumerable<TestPlanModel> TestPlans { get; set; }

   }
}
