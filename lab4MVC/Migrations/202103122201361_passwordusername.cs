namespace lab4MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordusername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.student", "password", c => c.String(nullable: false));
            AddColumn("dbo.student", "username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.student", "username");
            DropColumn("dbo.student", "password");
        }
    }
}
