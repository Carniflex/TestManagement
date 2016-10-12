using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities
{
    public class TestPlan:BaseEntity
    {


        public TestPlan() {

            this.CreatedDeate = DateTime.Now;
            this.SrsLink = "none";
        }

         [Required]
        public string TestPlanName { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public int ProjectId { get; set; }

        public string Author { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDeate { get; set; }

        public string SrsLink { get; set; }

        public string Status { get; set; }
        public virtual ICollection<TestSuite> TestSuites { get; set; }
    }
}
