namespace TMS.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorTestCase2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TestCases", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestCases", "Description", c => c.String());
        }
    }
}
