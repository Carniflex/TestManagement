using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TMS.Domain.Entities;

namespace TMS.Domain.EFMapping
{
    public class UserMap : EntityTypeConfiguration<UserProfile>
    {

        public UserMap()
        {

            HasKey(t => t.UserId);

            Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.UserName);

            ToTable("UserProfile");  
        }
    }
}
