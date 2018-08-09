namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fb2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FacebookToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FacebookToken");
        }
    }
}
