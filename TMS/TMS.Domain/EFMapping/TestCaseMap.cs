using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TMS.Domain.Entities;

namespace TMS.Domain.EFMapping
{
    public class TestCaseMap : EntityTypeConfiguration<TestCase>
    {

        public TestCaseMap()
        {

            HasKey(t => t.ID);

            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.TestCaseName);

            Property(t => t.Steps);


            Property(t => t.RunStatus);

            Property(t => t.TestSuiteId).IsRequired();

          

            HasRequired(t => t.TestSuite).WithMany(p => p.TestCases).HasForeignKey(t => t.TestSuiteId).WillCascadeOnDelete(false);
        }
    }
}
