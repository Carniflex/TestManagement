using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities
{
    
    [Table("UserProfile")]
  public class UserProfile
    {

     
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            public string UserName { get; set; }
            public ICollection<Project> Projects { get; set; }
        }
    }

