namespace lab4MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.departments",
                c => new
                    {
                        dept_id = c.Int(nullable: false),
                        dept_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.dept_id);
            
            CreateTable(
                "dbo.student",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        age = c.Int(nullable: false),
                        email = c.String(),
                        Department_dept_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.departments", t => t.Department_dept_id)
                .Index(t => t.Department_dept_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.student", "Department_dept_id", "dbo.departments");
            DropIndex("dbo.student", new[] { "Department_dept_id" });
            DropTable("dbo.student");
            DropTable("dbo.departments");
        }
    }
}
