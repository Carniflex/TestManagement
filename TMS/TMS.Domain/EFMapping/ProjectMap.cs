using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TMS.Domain.Entities;

namespace TMS.Domain.EFMapping
{
    public class ProjectMap : EntityTypeConfiguration<Project>
    {

        public ProjectMap()
        {

            HasKey(t => t.ID);

            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.ProjectName);

            Property(t => t.PaymentType);

            Property(t => t.Status);

            Property(t => t.UserId).IsRequired();

            ToTable("Projects");

            HasRequired(t => t.User).WithMany(p => p.Projects).HasForeignKey(t => t.UserId).WillCascadeOnDelete(false);
        }
    }
}
