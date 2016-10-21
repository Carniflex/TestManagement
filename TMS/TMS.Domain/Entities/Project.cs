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

      public string ProjectName { get; set; }

      [ForeignKey("UserId")]
      public UserProfile User { get; set; }

      public int UserId { get; set; }

      public ICollection<ProjectVersion> ProjectVersions { get; set; }

   }
}
