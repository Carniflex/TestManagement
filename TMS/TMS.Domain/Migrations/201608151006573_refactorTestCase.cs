namespace TMS.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorTestCase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestCases", "Steps", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestCases", "Steps");
        }
    }
}
