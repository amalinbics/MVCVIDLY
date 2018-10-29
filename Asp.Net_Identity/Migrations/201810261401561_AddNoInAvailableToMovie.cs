namespace Asp.Net_Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoInAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NoInAvailable", c => c.Int(nullable: false));
            Sql("UPDATE MOVIES SET NoInAvailable = NoInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NoInAvailable");
        }
    }
}
