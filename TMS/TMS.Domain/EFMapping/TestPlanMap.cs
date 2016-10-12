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
    public class TestPlanMap : EntityTypeConfiguration<TestPlan>
    {

        public TestPlanMap()
        {

            HasKey(t => t.ID);

            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.TestPlanName).IsRequired();

            Property(t => t.ProjectId).IsRequired();

            Property(t => t.Author);

            Property(t => t.CreatedDeate);

            Property(t => t.Status);

            Property(t => t.SrsLink);

            ToTable("Projects");

            HasRequired(t => t.Project).WithMany(p => p.TestPlans).HasForeignKey(t => t.ProjectId).WillCascadeOnDelete(false);
        }
    }
}
