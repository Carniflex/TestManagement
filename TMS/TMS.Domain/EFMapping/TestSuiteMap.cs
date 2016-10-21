using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;


namespace TMS.Domain.Mapping
{
    public class TestSuiteMap : EntityTypeConfiguration<TestSuite>
    {
        public TestSuiteMap()
        {

            HasKey(t => t.ID);

            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.TestSuiteName);

            Property(t => t.TestPlanId).IsRequired();

            HasRequired(t => t.TestPlan).WithMany(p => p.TestSuites).HasForeignKey(t => t.TestPlanId).WillCascadeOnDelete(false);
        }

    }
}
