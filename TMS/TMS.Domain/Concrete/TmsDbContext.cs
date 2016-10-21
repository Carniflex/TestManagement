using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;

namespace TMS.Domain.Concrete
{
   public class TmsDbContext: DbContext
    {
       public TmsDbContext()
           : base("name=TmsDb") 
       {
       
       }
      

       public DbSet<Project> Projects { get; set; }

       public DbSet<TestPlan> TestPlans { get; set; }

       public DbSet<TestSuite> TestSuites { get; set; }

       public DbSet<TestCase> TestCases { get; set; }
       public DbSet<ProjectVersion> ProjectVersions { get; set; }

       public DbSet<TestCaseRunStatus> RunStatuses { get; set; }

       public DbSet<UserProfile> UserProfiles { get; set; }

      
    }
}
