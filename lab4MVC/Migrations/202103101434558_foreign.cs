namespace lab4MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreign : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.student", "Department_dept_id", "dbo.departments");
            DropIndex("dbo.student", new[] { "Department_dept_id" });
            RenameColumn(table: "dbo.student", name: "Department_dept_id", newName: "Dept_id");
            AlterColumn("dbo.student", "Dept_id", c => c.Int(nullable: false));
            CreateIndex("dbo.student", "Dept_id");
            AddForeignKey("dbo.student", "Dept_id", "dbo.departments", "dept_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.student", "Dept_id", "dbo.departments");
            DropIndex("dbo.student", new[] { "Dept_id" });
            AlterColumn("dbo.student", "Dept_id", c => c.Int());
            RenameColumn(table: "dbo.student", name: "Dept_id", newName: "Department_dept_id");
            CreateIndex("dbo.student", "Department_dept_id");
            AddForeignKey("dbo.student", "Department_dept_id", "dbo.departments", "dept_id");
        }
    }
}
