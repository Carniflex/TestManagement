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
    public class TestCaseMap : EntityTypeConfiguration<TestCase>
    {

        public TestCaseMap()
        {

            HasKey(t => t.ID);

            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.TestCaseName);

            Property(t => t.Author);

           Property(t => t.Steps);


            Property(t => t.RunStatus);

            Property(t => t.SrsLink);

            Property(t => t.TestSuiteId).IsRequired();

            ToTable("Projects");

            HasRequired(t => t.TestSuite).WithMany(p => p.TestCases).HasForeignKey(t => t.TestSuiteId).WillCascadeOnDelete(false);
        }
    }
}
