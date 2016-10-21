using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TMS.Domain.Entities;

namespace TMS.Domain.EFMapping
{
    public class TestPlanMap : EntityTypeConfiguration<TestPlan>
    {

        public TestPlanMap()
        {

            HasKey(t => t.ID);

            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.TestPlanName).IsRequired();

            Property(t => t.ProjectVersionId).IsRequired();

            ToTable("ProjectVersions");

            HasRequired(t => t.ProjectVersion).WithMany(p => p.TestPlans).HasForeignKey(t => t.ProjectVersionId).WillCascadeOnDelete(false);
        }
    }
}
