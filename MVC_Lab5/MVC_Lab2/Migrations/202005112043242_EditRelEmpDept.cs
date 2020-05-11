namespace MVC_Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRelEmpDept : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "FK_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employee", new[] { "FK_DepartmentId" });
            AlterColumn("dbo.Employee", "FK_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "FK_DepartmentId");
            AddForeignKey("dbo.Employee", "FK_DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "FK_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employee", new[] { "FK_DepartmentId" });
            AlterColumn("dbo.Employee", "FK_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employee", "FK_DepartmentId");
            AddForeignKey("dbo.Employee", "FK_DepartmentId", "dbo.Departments", "Id");
        }
    }
}
