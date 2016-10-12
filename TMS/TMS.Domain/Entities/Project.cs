using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities
{
   public class Project:BaseEntity
    {

      [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
      public string ProjectName { get; set; }

        [Required]
      public string PaymentType { get; set; }

         [Required]
      public string Status { get; set; }

      [ForeignKey("UserId")]
      public UserProfile User { get; set; }

      public int UserId { get; set; }

      public virtual ICollection<TestPlan> TestPlans { get; set; }

   }
}
